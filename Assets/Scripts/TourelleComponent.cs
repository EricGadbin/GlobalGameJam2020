using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TourelleComponent : MonoBehaviour
{
    private ShotComponent ShotComponent;
    public int enemyLayer;

    void Start()
    {
        ShotComponent = GetComponent<ShotComponent>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer && collision.gameObject.GetComponent<HealthComponent>() && !collision.gameObject.GetComponent<HealthComponent>().IsDead)
        {
            Vector2 direction = collision.transform.position - transform.position;
            ShotComponent.Shoot(direction.normalized);
        }
    }
    
    // private ShotComponent ShotComponent;
    // public int enemyLayer;
    // public GameObject target = null;

    // void Start()
    // {
    //     ShotComponent = GetComponent<ShotComponent>();
    // }

    // private void Update() {
    //     if (target) {
    //         Vector2 direction = target.transform.position - transform.position;
    //         ShotComponent.Shoot(direction.normalized);
    //     }

    // }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.layer == enemyLayer && collision.gameObject.GetComponent<HealthComponent>() && !collision.gameObject.GetComponent<HealthComponent>().IsDead)
    //     {
    //         target = collision.gameObject;
    //     }
    // }

    // private void OnTriggerStay2D(Collider2D collision) {
        
    //     if (!target && collision.gameObject.layer == enemyLayer && collision.gameObject.GetComponent<HealthComponent>() && !collision.gameObject.GetComponent<HealthComponent>().IsDead)
    //     {
    //         target = collision.gameObject;
    //     }
    // }

    // private void OnTriggerExit2D(Collider2D other) {
    //     if (other.gameObject == target) {
    //         target = null;
    //     }
    // }
}
