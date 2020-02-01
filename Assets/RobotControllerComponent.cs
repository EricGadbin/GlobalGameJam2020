using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControllerComponent : MonoBehaviour
{
    // private static List<EnemyControllerComponent> allEnemies
    private int group = 0;

    PathFollowComponent pathFollow;
    RobotBodyComponent body;
    PickableComponent pickable;
    RobotControllerComponent target;
    SlotComponent actualSlot = null;

    public RobotControllerComponent GetTarget()
    {
        return target;
    }

    public void AcquireTarget(RobotControllerComponent newTarget)
    {
        target = newTarget;
    }

    private void Start() {
        pathFollow = GetComponent<PathFollowComponent>();
        body = GetComponent<RobotBodyComponent>();
        pickable = GetComponent<PickableComponent>();
        pickable.OnDropped.AddListener(Dropped);
        body.enabled = false;
    }

    private void GetDestruct() {
        body.enabled = false;
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
