using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBodyComponent : SlotComponent
{
    [SerializeField]
    private PickableComponent legs = null;
    [SerializeField]
    private PickableComponent arms = null;
    [SerializeField]
    private PickableComponent head = null;
    [SerializeField]
    bool isFull = false;

    public void BreakIt() {
        int j = 0;
        for(int i = Random.Range(0, 2); i < 3; i++) {
            j = Random.Range(0, 2);
            if (j == 0)
                legs = null;
            if (j == 1)
                arms = null;
            if (j == 2)
                head = null;
        }
        isFull = false;
    }

    public bool GetStatut() {
        return isFull;
    }

    private void CompleteRepair()
    {
        isFull = true;
        GetComponent<PickableComponent>().enabled = true;
        GetComponent<PickableComponent>().GetSlot().enabled = true;
        this.enabled = false;
    }

    override public bool TryDrop(PickableComponent toStock) {
        if (!legs && toStock.Type == IPickableObject.ROBOT_LEG) {
            legs = toStock;
            legs.GetComponent<PickableComponent>().enabled = false;
            legs.transform.parent = transform;
            legs.transform.position = transform.position;
            if (head && arms && legs) {
                CompleteRepair();
            }
            return true;
        }
        if (!arms && toStock.Type == IPickableObject.ROBOT_ARM) {
            arms = toStock;
            arms.GetComponent<PickableComponent>().enabled = false;
            arms.transform.parent = transform;
            arms.transform.position = transform.position;
            if (head && arms && legs) {
                CompleteRepair();
            }
            return true;
        }
        if (!head && toStock.Type == IPickableObject.ROBOT_HEAD) {
            head = toStock;
            head.GetComponent<PickableComponent>().enabled = false;
            head.transform.parent = transform;
            head.transform.position = transform.position;
            if (head && arms && legs) {
                CompleteRepair();
            }
            return true;
        }
        //maybe event
        return false;
    }
    override public PickableComponent TryPick() {
        if (isFull) {
            return GetComponent<PickableComponent>();
        }
        return null;
    }
}
