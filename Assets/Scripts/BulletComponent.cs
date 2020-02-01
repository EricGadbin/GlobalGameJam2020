using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    [SerializeField]
    private float damages = 0;

    [SerializeField]
    private string hittable = "";

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.GetComponent<HealthComponent>() && hittable == other.gameObject.tag)
        {
            other.GetComponent<HealthComponent>().GetDamages(damages);
        }
    }
}
