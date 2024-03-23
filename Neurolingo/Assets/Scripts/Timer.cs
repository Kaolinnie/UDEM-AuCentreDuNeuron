using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public int numOfSeconds;
    
    private TextMeshProUGUI timerText;

    private float timeLeft;
    private bool continueTimer;

    // Start is called before the first frame update
    void Start() {
        timeLeft = numOfSeconds;
        timerText = GetComponent<TextMeshProUGUI>();
        continueTimer = true;
        
    }

    // Update is called once per frame
    void Update() {
        if (!continueTimer) return;
        if (timeLeft <= 0.0f) {
            timerComplete();
            return;
        }
        
        timeLeft -= Time.deltaTime;
        timerText.text = $"{(int)timeLeft}";
    }

    void timerComplete() {
        continueTimer = false;
        Debug.Log("Your timer is complete");
    }
}
