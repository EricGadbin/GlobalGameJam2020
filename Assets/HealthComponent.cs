using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    private float life = 100;

    public void GetDamages(float number)
    {
        life -= number;
    }
}
