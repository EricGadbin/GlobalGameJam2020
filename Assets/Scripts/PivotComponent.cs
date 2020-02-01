using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotComponent : MonoBehaviour
{
    private PlayerControllerComponent controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<PlayerControllerComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.Movement != Vector2.zero) {
            Vector3 dir = controller.Movement;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
