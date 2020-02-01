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

    getC

}
