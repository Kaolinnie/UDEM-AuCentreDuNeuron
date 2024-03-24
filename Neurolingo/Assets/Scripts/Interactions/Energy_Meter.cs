using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Energy_Meter : MonoBehaviour {
    private float energy = -70.0f;

    public TextMeshProUGUI text;

    private Animator animator;
    private static readonly int Energy1 = Animator.StringToHash("Energy");

    private float sodiumLevel = 0;
    private float potassiumLevel = 0;


    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        animator.SetFloat(Energy1, energy);
        text.text = $"{(int) Energy}";
    }

    public float Energy {
        get { return Mathf.Clamp(energy + sodiumLevel - potassiumLevel, -85, 50); }
        set {
            energy = value;
        }
    }

    public float SodiumLevel {
        get { return sodiumLevel; }
        set {
            sodiumLevel = value;

        }
    }

    public float PotassiumLevel {
        get { return potassiumLevel; }
        set {
            potassiumLevel = value;
        }
    }

    public void Stabilise() {
        energy += 2.5f * Time.deltaTime;
    }
}
