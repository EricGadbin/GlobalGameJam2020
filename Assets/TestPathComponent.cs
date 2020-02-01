using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPathComponent : MonoBehaviour
{
    PathFollowComponent pathFollow;
    Vector2 pos;
    Transform player;
    private void Start() {
        pathFollow = GetComponent<PathFollowComponent>();
        pos = transform.position;
        player = GameObject.Find("Player").transform;
        GoTo();
    }

    bool shouldSwitch = false;
    public void GoTo()
    {
        if (shouldSwitch) {
            pathFollow.SeekPath(pos);
            shouldSwitch = false;
        } else {
            pathFollow.SeekPath(player.transform.position);
            shouldSwitch = true;
        }
    }
}
