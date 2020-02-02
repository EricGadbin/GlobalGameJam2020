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
    [SerializeField]
    private float _life = 0f;

    private float life {
        get {return _life;}
        set {
            _life = Mathf.Clamp(value, 0, maxHealth);
        }
    }
    public UnityEventFloat OnTakeDamage = new UnityEventFloat();

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
        OnTakeDamage.Invoke(life/maxHealth);
        if (life == 0) {
            OnDeathEvent.Invoke();
        }
    }
}
