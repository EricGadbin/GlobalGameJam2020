using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControllerComponent : MonoBehaviour
{
    // private static List<EnemyControllerComponent> allEnemies
    private int group = 0;

    PathFollowComponent pathFollow;
    RobotBodyComponant body;
    PickableComponent pickable;


    private void Start() {
        pathFollow = GetComponent<PathFollowComponent>();
    }

    private void GetDestruct() {
        body = GetComponent<RobotBodyComponant>();
        body.enabled = !body.enabled;
    }

    private void Dropped() {
        pickable = GetComponent<PickableComponent>();
        pickable.enabled = !pickable.enabled;
        body = GetComponent<RobotBodyComponant>();
        body.enabled = body.enabled;
        body.BreakIt();
        pickable.GetSlot().enabled = !pickable.GetSlot().enabled;
    }

    private void Picked() {
        body = GetComponent<RobotBodyComponant>();
        if (body.GetStatut() == true)
        {
            pickable = GetComponent<PickableComponent>();
            pickable.enabled = pickable.enabled;
            pickable.GetSlot().enabled = pickable.GetSlot().enabled;
        }   
    }
}
