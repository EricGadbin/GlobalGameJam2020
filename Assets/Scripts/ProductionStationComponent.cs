using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionStationComponent : SlotComponent
{
    [SerializeField]
    private GameObject toCreate = null;
    [SerializeField]
    private int require = 3;
    [SerializeField]
    private GameObject owner = null;
    [SerializeField]
    private float timeToBuild = 5f;
    private float timer = 0f;
    private bool isRunning = false;

    override public PickableComponent TryPick() {
        PickableComponent tmp = stockedObject;

        if (tmp != null) {
            stockedObject = null;
            return tmp;
        }
        if (owner.GetComponent<MoneyComponent>().buy(require)) {
            isRunning = true;
            timer = 0f;
        }
        return null;
    }

    override public bool TryDrop(PickableComponent toStock) {
        if (isRunning)
            return false;
        return base.TryDrop(toStock);
    }

    void Update() {
        if (!isRunning)
            return;
        GameObject tmp = null;
        timer += Time.deltaTime;
        if (timer >= timeToBuild) {
            tmp = Instantiate(toCreate, transform.position, transform.rotation);
            isRunning = false;
            TryDrop(tmp.GetComponent<PickableComponent>());
            Debug.Log(stockedObject);
        }
    }
}
