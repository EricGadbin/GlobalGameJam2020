﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKillerComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "Bullet")
            Destroy(other.gameObject);
    }
}
