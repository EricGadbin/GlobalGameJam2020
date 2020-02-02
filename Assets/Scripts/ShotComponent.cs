using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab = null;
    [SerializeField]
    private float cooldown = 2;

    private bool active = false;
    private float timer;

    private void Start() {
        timer = cooldown;
    }

    public void setCooldown(float time)
    {
        cooldown = time;
    }

    private void Update() {
        if (!active) {
            if (timer > 0) {
                timer -= Time.deltaTime;
            } else {
                active = true;
            }
        }
    }

    public void Shoot(Vector2 direction)
    {
        if (active) {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            GameObject obj = Instantiate(prefab, gameObject.transform.position, Quaternion.AngleAxis(angle, Vector3.forward)) as GameObject;
            obj.GetComponent<BulletComponent>().setDirection(direction.normalized);
            active = false;
            timer = cooldown;
        }
    }
}
