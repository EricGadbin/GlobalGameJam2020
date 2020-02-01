using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyComponent : MonoBehaviour
{     
    private int money = 0;
    [SerializeField]
    private float incomeSpeed = 2f;
    private float incomeTimer = 2f;
    [SerializeField]
    private int income = 1;

    public bool buy(int cost)
    {
        if (money < cost)
            return false;
        money -= cost;
        Debug.Log(money);
        return true;
    }
     public void AddMoney(int value)
    {
        money += value;
        Debug.Log(money);
    }
    private void Update()
    {
        incomeTimer -= Time.deltaTime;
        if (incomeTimer <= 0f) {
            money += income;
            incomeTimer = incomeSpeed;
            // Debug.Log(money);
        }
    }
   
}
