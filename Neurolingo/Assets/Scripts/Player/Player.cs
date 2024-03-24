using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private Camera cam;
    private float walkSpeed = 1.0f;
    private Rigidbody2D rb;
    private Animator animator;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private GameObject action;
    private bool isWalking;
    private SpriteRenderer sprite;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update() {
        if (Input.GetKeyDown("escape")) {
            Navigation nav = new Navigation();
            nav.ClickGoBack();
        }
        
        animator.SetBool(IsWalking, isWalking);
        if (isWalking) {
            Move();
            return;
        }
        ClickChecker();
    }

    void ClickChecker() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                if (action == hit.collider.gameObject) {
                    if (action.transform.name == "Mailbox") {
                        GameManager gm = GameManager.Instance;
                        gm.SendMail();
                        return;
                    }
                    Valve script = action.GetComponent<Valve>();
                    script.RotateValve();
                    return;
                }
                action = hit.collider.gameObject;
                isWalking = true;
            }
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void Move() {
        var step = walkSpeed * Time.deltaTime;
        Vector3 destination = new Vector3(action.transform.position.x - 0.3f,transform.position.y, 20);
        transform.position = Vector3.MoveTowards(transform.position, destination, step);
        sprite.flipX = destination.x - transform.position.x < 0;
        var distance = Vector2.Distance(transform.position, destination);
        if ( distance < 0.1f) {
            sprite.flipX = false;
            isWalking = false;
        }

    }
}
