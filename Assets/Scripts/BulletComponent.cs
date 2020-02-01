using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [SerializeField]
    private float damages = 0;

    [SerializeField]
    private string hittable = "";

    [SerializeField]
    private float speed = 0.06f;

    [SerializeField]
    private Vector2 direction = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<HealthComponent>() && hittable == other.gameObject.tag)
        {
            other.GetComponent<HealthComponent>().GetDamages(damages);
        }
        Destroy(this.gameObject);
    }

    public void setDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void setDamage(float newDamage)
    {
        damages = newDamage;
    }

    public void setHittable(string newHittable)
    {
        hittable = newHittable;
    }

    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, direction, speed);
    }
}
