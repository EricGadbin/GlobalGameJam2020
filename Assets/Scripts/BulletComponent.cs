using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [SerializeField]
    private float damages = 0;

    [SerializeField]
    private float speed = 0.06f;

    [SerializeField]
    private Vector2 direction = Vector2.zero;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    IEnumerator Hit(Collider2D other)
    {
        if (other.GetComponent<HealthComponent>())
        {
            other.GetComponent<HealthComponent>().GetDamages(damages);
        }
        direction = Vector2.zero;
        animator.SetBool("HasHit", true);
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        Destroy(this.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        StartCoroutine("Hit", other);
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
    
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
