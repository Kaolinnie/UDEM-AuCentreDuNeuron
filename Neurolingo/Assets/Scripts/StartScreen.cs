using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public Animator animator;
    public GameObject imageToActivate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void LoadScene(){
        SceneManager.LoadScene("Game");
    }
    // Clicking the start button
    public void ClickStart() {
        imageToActivate.SetActive(true);
        animator.SetTrigger("FadeOut");
        Invoke("LoadScene",1);
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

}
