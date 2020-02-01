using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBodyComponant : SlotComponent
{
    private PickableComponent legs = null;
    private PickableComponent arms = null;
    private PickableComponent head = null;
    bool isFull = true;

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

    override public bool TryDrop(PickableComponent toStock) {
        if (!legs && toStock.Type == IPickableObject.ROBOT_LEG) {
            legs = toStock;
            if (head && arms && legs)
                isFull = true;
            return true;
        }
        if (!arms && toStock.Type == IPickableObject.ROBOT_ARM) {
            arms = toStock;
            if (head && arms && legs)
                isFull = true;
            return true;
        }
        if (!head && toStock.Type == IPickableObject.ROBOT_HEAD) {
            head = toStock;
            if (head && arms && legs)
                isFull = true;
            return true;
        }
        //maybe event
        return false;
    }
    override public PickableComponent TryPick() {
        return null;
    }
}
