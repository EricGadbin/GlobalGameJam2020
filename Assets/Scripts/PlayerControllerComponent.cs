using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class PlayerControllerComponent : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private string VerticalInputName = "Vertical";
    [SerializeField]
    private string HorizontalInputName = "Horizontal";
    [SerializeField]
    private KeyCode ActionInputKey = KeyCode.Space;
    [SerializeField]
    private UnityEvent OnActionInput = new UnityEvent();
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
        movement = Vector2.up * Input.GetAxisRaw(VerticalInputName) + Vector2.right * Input.GetAxisRaw(HorizontalInputName);

        if (Input.GetKeyDown(ActionInputKey)) {
            Debug.Log("Allo ?");
            OnActionInput.Invoke();
        }
    }

    private void FixedUpdate() {
        movement *= speed;
        movement *= Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);
    }

}
