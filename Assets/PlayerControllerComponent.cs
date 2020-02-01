using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerComponent : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    private Vector2 movement = Vector2.zero;
    public Vector2 Movement {
        get {return movement;}
    }
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        movement = Vector2.up * Input.GetAxisRaw("Vertical") + Vector2.right * Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() {
        movement *= speed;
        movement *= Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);
    }

}
