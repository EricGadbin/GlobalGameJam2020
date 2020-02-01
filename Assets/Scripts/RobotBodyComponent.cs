using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBodyComponant : SlotComponent
{
    private PickableComponent legs = null;
    private PickableComponent arms = null;
    private PickableComponent head = null;
    bool isFull = true;

    override public bool TryDrop(PickableComponent toStock) {
        if (!legs && toStock.Type == IPickableObject.ROBOT_LEG) {
            legs = toStock;
            return true;
        }
        if (!arms && toStock.Type == IPickableObject.ROBOT_ARM) {
            arms = toStock;
            return true;
        }
        if (!head && toStock.Type == IPickableObject.ROBOT_HEAD) {
            head = toStock;
            return true;
        }
        //maybe event
        return false;
    }
    override public PickableComponent TryPick() {
        return null;
    }
}
