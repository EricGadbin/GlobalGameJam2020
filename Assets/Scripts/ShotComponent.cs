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

    public void setCooldown(float time)
    {
        cooldown = time;
    }

    public void Shoot(Vector2 position)
    {
        if (active)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
                active = false;
        } else
        {
            GameObject obj = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
            obj.GetComponent<BulletComponent>().setDirection(position);
            active = true;
            timer = cooldown;
        }
    }
}
