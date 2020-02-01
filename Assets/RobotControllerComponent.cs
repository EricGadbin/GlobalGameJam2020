using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControllerComponent : MonoBehaviour
{
    PathFollowComponent pathFollow = null;
    RobotBodyComponent body = null;
    PickableComponent pickable = null;
    GameObject target = null;
    SlotComponent actualSlot = null;
    ShotComponent shot = null;
    Animator animator = null;
    TeamComponent team = null;
    SensorComponent sensor = null;

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
        pathFollow = GetComponent<PathFollowComponent>();
        body = GetComponent<RobotBodyComponent>();
        pickable = GetComponent<PickableComponent>();
        shot = GetComponent<ShotComponent>();
        animator = GetComponent<Animator>();
        team = GetComponent<TeamComponent>();
        pickable.OnDropped.AddListener(Dropped);
        sensor = GetComponentInChildren<SensorComponent>();
        body.enabled = false;
    }

    public void GetDestruct() {
        body.enabled = false;
        pathFollow.StopAllCoroutines();
        
        pathFollow.enabled = false;
        shot.enabled = false;
        target = null;
        animator.enabled = false;
        team.enabled = false;
        sensor.enabled = false;
        
        body.BreakIt();
    }

    public void Activate()
    {
        
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
