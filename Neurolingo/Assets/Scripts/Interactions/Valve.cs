using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour {
    private Animator animator;
    private static readonly int Rotate = Animator.StringToHash("Rotate");
    private bool isOpen = false;

    public GameObject pipe_obj;
    private Pipe pipe_scr;

    public void RotateValve() {
        isOpen = !isOpen;
        pipe_scr.IsValveOpen = isOpen;
        animator.SetTrigger(Rotate);
    }
    // Start is called before the first frame update
    void Start() {
        pipe_scr = pipe_obj.GetComponent<Pipe>();
        animator = GetComponent<Animator>();
    }
}
