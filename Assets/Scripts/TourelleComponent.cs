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
        if (collision.gameObject.tag == "Player")
        {
            Vector2 direction = collision.transform.position - transform.position;
            ShotComponent.Shoot(direction.normalized);
        }
    }
}
