using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{

    // Clicking the start button
    public void ClickStart() {
        SceneManager.LoadScene("Game");
    }

    public void ClickControls() {
        Debug.Log("You clicked controls");

    }

    public void ClickLanguage() {
        Debug.Log("You clicked the language button");

    }

    public void ClickLeaderboard() {
        Debug.Log("You clicked the leaderboard button");
    }

    public void ClickExit() {
        Application.Quit();
    }
    
    public void ClickGoBack() {
        SceneManager.LoadScene("StartScreen");
        Debug.Log("go back");
    }

    public void ClickInfo() {
        SceneManager.LoadScene("Info");

    }

}
