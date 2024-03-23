using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToMainScreen : MonoBehaviour
{
    public void ClickGoBack() {
        SceneManager.LoadScene("StartScreen");
        Debug.Log("go back");
    }
}
