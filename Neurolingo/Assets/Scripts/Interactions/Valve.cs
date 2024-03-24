using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour {
    private Animator animator;
    private static readonly int Rotate = Animator.StringToHash("Rotate");

    private bool isRotating = false;

    public void RotateValve() {
        isRotating = !isRotating;
        Debug.Log($"rotating valve {transform.name}");
    }
    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(Rotate, isRotating);
    }
}
