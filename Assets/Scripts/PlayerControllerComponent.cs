using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PlayerControllerComponent : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private Transform SpawnPosition = null;
    [SerializeField]
    private string VerticalInputName = "Vertical";
    [SerializeField]
    private string HorizontalInputName = "Horizontal";
    [SerializeField]
    private KeyCode ActionInputKey = KeyCode.Space;
    [SerializeField]
    private UnityEvent OnActionInput = new UnityEvent();
    [SerializeField]
    private float timeLeft = 10;
    private float tmpTimeLeft = 10;
    private bool isDead = false;
    private Vector2 movement = Vector2.zero;
    public Vector2 Movement {
        get {return movement;}
    }
    private Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (isDead == false) {
            movement = Vector2.up * Input.GetAxisRaw(VerticalInputName) + Vector2.right * Input.GetAxisRaw(HorizontalInputName);
            if (Input.GetKeyDown(ActionInputKey)) {
                Debug.Log("Allo ?");
                OnActionInput.Invoke();
            }
        } 
        if (isDead == true) {
            tmpTimeLeft -= Time.deltaTime;
            Debug.Log(tmpTimeLeft);
            if (tmpTimeLeft <= 0) {
                Debug.Log("Entered");
                isDead = false;
            }
         }
    }

    private void FixedUpdate() {
        movement = movement.normalized;
        movement *= speed;
        movement *= Time.fixedDeltaTime;
        // Debug.Log(movement.y);
        animator.SetBool("moveUp", movement.y > 0);
        animator.SetBool("moveDown", movement.y < 0);
        animator.SetBool("moveLeft", movement.x < 0);
        animator.SetBool("moveRight", movement.x > 0);
        animator.SetBool("isMoving", movement.magnitude != 0);
        rb.MovePosition(rb.position + movement);
    }

    public void OnDeath()
    {
        if (SpawnPosition) {
            transform.position = SpawnPosition.position;
            isDead = true;
            tmpTimeLeft = timeLeft;
        }
    }

}
