using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;
    private float _life = 0;

    private float life {
        get {return _life;}
        set {
            _life = Mathf.Clamp(value, 0, maxHealth);
        }
    }
    public UnityEvent OnDeathEvent = new UnityEvent();

    void Start()
    {
        life = maxHealth;        
    }

    public void GetDamages(float number)
    {
        if (!enabled)
            return;
        life -= number;
        if (life == 0) {
            OnDeathEvent.Invoke();
        }
    }
}
