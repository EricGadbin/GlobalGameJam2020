using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControllerComponent : MonoBehaviour
{
    [SerializeField]
    private Sprite brokenPartSprite = null;
    PathFollowComponent pathFollow = null;
    RobotBodyComponent body = null;
    PickableComponent pickable = null;
    [SerializeField]
    GameObject target = null;
    SlotComponent actualSlot = null;
    ShotComponent shot = null;
    Animator animator = null;
    TeamComponent team = null;
    SensorComponent sensor = null;
    Rigidbody2D rb = null;
    HealthComponent health = null;
    [SerializeField] GameObject hpBar = null;
    Collider2D coll = null;
    SpriteRenderer sprite;
    Color baseColor;

    public GameObject GetTarget()
    {
        return target;
    }

    public void AcquireTarget(GameObject newTarget)
    {
        pathFollow.StopAllCoroutines();
        target = newTarget;
    }

    private void Start() {

        //Get way too many references
        pathFollow = GetComponent<PathFollowComponent>();
        body = GetComponent<RobotBodyComponent>();
        pickable = GetComponent<PickableComponent>();
        shot = GetComponent<ShotComponent>();
        animator = GetComponent<Animator>();
        team = GetComponent<TeamComponent>();
        health = GetComponent<HealthComponent>();
        sensor = GetComponentInChildren<SensorComponent>();
        coll = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
        baseColor = sprite.color;
        pickable.OnDropped.AddListener(Dropped);
        body.enabled = false;
    }

    IEnumerator Eject()
    {
        Vector2 direction = new Vector2(Random.Range(-10, 10),Random.Range(-10, 10)).normalized;
        rb.AddForce(direction * 100);
        
        yield return new WaitForSeconds(2f);
        Destroy(rb);

    }

    public void GetDestruct() {
        pathFollow.enabled = false;
        pathFollow.StopAllCoroutines();

        body.BreakIt();
        body.enabled = false;
        shot.enabled = false;
        team.enabled = false;
        sensor.enabled = false;
        health.enabled = false;
        animator.enabled = false;

        coll.isTrigger = true;
        target = null;
        // hpBar.SetActive(false);

        pickable.enabled = true;
        
        sprite.sprite = brokenPartSprite;
        sprite.color = baseColor;
        Destroy(rb);
    }

    public void GetRepair()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;
        rb.bodyType = RigidbodyType2D.Kinematic;

        body.Activate();
        body.enabled = false;
        pathFollow.enabled = true;
        shot.enabled = true;
        animator.enabled = true;
        team.enabled = true;
        sensor.enabled = true;
        health.enabled = true;
        pickable.enabled = false;
        hpBar.SetActive(true);
        health.Resurrect();
        coll.isTrigger = false;
        
        sprite.color = Color.white;
    }

    public void Dropped(GameObject newSlot) {
        actualSlot = newSlot.GetComponent<SlotComponent>();
        if (body.IsFull() == false) {
            body.enabled = true;
            actualSlot.enabled = false;
            pickable.enabled = false;
        }
    }

}
