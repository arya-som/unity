using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    private Button[] buttons;
    
    void Awake()
    {
        //get the buttons
        buttons = GetComponentsInChildren<Button>();

        //Disable them
        HideButtons();
    }

    public void HideButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }

    public void ShowButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void ExitToMenu()
    {
        //Load menu
        Application.LoadLevel("menu");
    }

    public void RestartGame()
    {
        //Reload the level
        Application.LoadLevel("mainlevel");
    }
}

