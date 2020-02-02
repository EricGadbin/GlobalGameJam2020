using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int>
{
}


public class MoneyComponent : MonoBehaviour
{     
    private int money = 0;
    [SerializeField]
    private float incomeSpeed = 2f;
    private float incomeTimer = 2f;
    [SerializeField]
    private int income = 1;
    [SerializeField]
    public IntEvent OnMoneyUpdated = new IntEvent();

    public bool buy(int cost)
    {
        if (money < cost)
            return false;
        money -= cost;
        return true;
    }
     public void AddMoney(int value)
    {
        money += value;
    }
    private void Update()
    {
        incomeTimer -= Time.deltaTime;
        if (incomeTimer <= 0f) {
            money += income;
            incomeTimer = incomeSpeed;
            OnMoneyUpdated.Invoke(money);
        }
    }
}
