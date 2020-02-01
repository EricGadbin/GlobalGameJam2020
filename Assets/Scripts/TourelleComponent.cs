using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourelleComponent : MonoBehaviour
{
    private ShotComponent ShotComponent;

    void Start()
    {
        ShotComponent = GetComponent<ShotComponent>();
        ShotComponent.setCooldown(5);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        ShotComponent.Shoot(collision.transform.position);
    }
}
