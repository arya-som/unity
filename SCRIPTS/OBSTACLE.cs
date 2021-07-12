using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBSTACLE : MonoBehaviour 
{
    public float speed;
    public float maxTransform;
    public float minTransform;
    private int direction = 1;

    void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);
        checkDirection();
    }

    public void checkDirection()
    {
        if (transform.position.x >= maxTransform)
        {
            direction = -1;
        }
        else if (transform.position.x <= minTransform)
        {
            direction = -1;
        }
    }
}