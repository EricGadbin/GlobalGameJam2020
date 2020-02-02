using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventFloat : UnityEvent <float> {

}

public class HealthComponent : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100f;
    public float MaxHealth {
        get {return maxHealth;}
    }
    [SerializeField]
    private float _life = 0f;

    public bool IsDead {
        get {return _life <= 0;}
    }

    private float life {
        get {return _life;}
        set {
            _life = Mathf.Clamp(value, 0, maxHealth);
        }
    }
    public UnityEventFloat OnLifeUpdate = new UnityEventFloat();

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
        OnLifeUpdate.Invoke(life/maxHealth);
        if (life == 0) {
            OnDeathEvent.Invoke();
        }
    }

    public void GetHeal(float amount)
    {
        if (!enabled)
            return;
        life += amount;
        OnLifeUpdate.Invoke(life/maxHealth);
    }

    public void Resurrect()
    {
        life = maxHealth;
        OnLifeUpdate.Invoke(life/maxHealth);
    }
}
