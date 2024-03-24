using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {
    private PipeType pipeType;
    private bool isValveOpen = false;

    private Animator animator;
    private static readonly int Filling = Animator.StringToHash("Filling");

    public GameObject energyMeterObj;
    private Energy_Meter energyMeter;

    public enum PipeType {
        PipeK,
        PipeNa,
        PipeNaK
    }
    
    
    // Start is called before the first frame update
    void Start() {
        pipeType = (PipeType) Enum.Parse(typeof(PipeType), gameObject.name);
        energyMeter = energyMeterObj.GetComponent<Energy_Meter>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(Filling,isValveOpen);
    }

    private void FixedUpdate() {
        if (!isValveOpen) return;
        switch (pipeType) {
            case PipeType.PipeK:
                energyMeter.PotassiumLevel += 5f * Time.deltaTime;
                break;
            case PipeType.PipeNa:
                energyMeter.SodiumLevel += 5f * Time.deltaTime;
                break;
            case PipeType.PipeNaK:
                energyMeter.Stabilise();
                break;
        }
    }

    public bool IsValveOpen {
        get { return isValveOpen; }
        set { isValveOpen = value; }
    }
}
