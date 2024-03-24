using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Camera cam;
    private float walkSpeed = 2.0f;
    [SerializeField] private Rigidbody2D rb;
    private Animator animator;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private GameObject action;
    private bool isWalking;
    void Start()
    {
        animator = GetComponent<Animator>();
        cam = Camera.main;
    }
    void Update() {
        animator.SetBool(IsWalking, isWalking);
        if (isWalking) {
            Move();
            return;
        }
        rb.velocity = Vector2.zero;
        transform.localScale = new Vector2(1.5f, 1.5f);
        ClickChecker();
    }

    void ClickChecker() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                if (action == hit.collider.gameObject) {
                    Valve script = action.GetComponent<Valve>();
                    script.RotateValve();
                    return;
                }
                action = hit.collider.gameObject;
                isWalking = true;
                Debug.Log(action.name);
            }
        }
    }

    void Move() {
        Vector2 destination = new Vector2(action.transform.position.x - 2,transform.position.y);

        if (destination.x - transform.position.x < 0) {
            transform.localScale = new Vector2(-1.5f, 1.5f);
        }

        if (Mathf.Abs(destination.x - transform.position.x) > 0.1f) {
            rb.velocity = new Vector2((destination.x - transform.position.x) * walkSpeed, 0);
        }
        else {
            isWalking = false;
        }
        
    }

}
