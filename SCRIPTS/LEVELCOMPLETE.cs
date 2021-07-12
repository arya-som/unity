using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LEVELCOMPLETE : MonoBehaviour
{
    public void ExitToMenu()
    {
        //Load menu
        Application.LoadLevel("menu");
    }


}