using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerComponent : MonoBehaviour
{
    // private static List<EnemyControllerComponent> allEnemies
    private int group = 0;

    PathFollowComponent pathFollow;

    private void Start() {
        pathFollow = GetComponent<PathFollowComponent>();
    }
}
