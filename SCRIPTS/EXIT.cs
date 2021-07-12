using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXIT : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Exit()
    {
        Debug.Log("GameQuit");
        Application.Quit();
    }
}
