
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PLAYER : MonoBehaviour
{
    [SerializeField]private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;

    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodycomponent;
    private int superJumpsRemaining;

    

    
    private float time = 0.0f;
    private bool isMoving = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbodycomponent = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //check if space key is pressed down
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

       
    }

    // Fixed Update is called every physics update
    private void FixedUpdate()
    {
        rigidbodycomponent.velocity = new Vector3(0, rigidbodycomponent.velocity.y, 10*horizontalInput);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            float jumpPower = 6f;
            if (superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                superJumpsRemaining--;
            }

            rigidbodycomponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }


        if (isMoving)
        {
            // when the cube has moved for 1 seconds, report its position
            time = time + Time.fixedDeltaTime;
            if (time > 1.0f)
            {
                Debug.Log(gameObject.transform.position.y + " : " + time);
                time = 0.0f;
            }
        }



    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            superJumpsRemaining++;
        }


        if (other.tag == "FALLDECTECTOR")
        {
            // Game Over.
            var gameOver = FindObjectOfType<GameOverScript>();
            gameOver.ShowButtons();
        }
        
        if(other.tag == "LEVELCOMPLETE")
        {
            //Level Complete.
            Application.LoadLevel("LEVELCOMPLETE");
        }

    }

    void OnDestroy()
    {
        // Game Over.
        var gameOver = FindObjectOfType<GameOverScript>();
        gameOver.ShowButtons();
    }


}
