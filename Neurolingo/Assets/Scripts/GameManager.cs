using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }
    private Mode mode;
    public GameObject timer;
    public GameObject stopwatch;
    public GameObject timeBox;

    private void Awake() {
        Instance = this;
        mode = Mode.SingleNeuronGame;
        setupTimer();
    }

    void setupTimer() {
        if (mode == Mode.SingleNeuronGame) {
            Instantiate(stopwatch, timeBox.transform);
        }
        if (mode == Mode.MultiNeuronGame) {
            Instantiate(timer, timeBox.transform);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
