using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLose : MonoBehaviour
{
    public static WinLose Instance { get; private set; }

    public static string message;

    public TextMeshProUGUI text;

    private void Awake() {
        Instance = this;
        if (SceneManager.GetActiveScene().name == "EndScreen") {
            text.text = message;
        }
    }

}
