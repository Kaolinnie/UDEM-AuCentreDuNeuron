using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour {
    private float numOfSeconds = 0;    
    private bool continueStopwatch;
    private TextMeshProUGUI timerText;
    
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        continueStopwatch = true;
    }

    // Update is called once per frame
    void Update() {
        if (!continueStopwatch) return;
        NumOfSeconds += Time.deltaTime;
        timerText.text = $"{(int)NumOfSeconds}";
    }

    public float StopTimer() {
        continueStopwatch = false;
        return NumOfSeconds;
    }
    
    public float NumOfSeconds {
        get { return numOfSeconds; }
        private set { numOfSeconds = value; }
    }
}
