using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReleaseComponent : SlotComponent
{
    [SerializeField]
    private Transform drop = null;

    override public bool TryDrop(PickableComponent toStock) {
        if (toStock.Type==IPickableObject.ROBOT_BODY && toStock.GetRobotBody().IsFull()) {
            //StartCoroutine(waiting());
            toStock.transform.parent = null;
            toStock.transform.position = drop.position;
            toStock.GetComponent<RobotControllerComponent>().Activate();
            return true;
        }
        return false;
    }

    //IEnumerator waiting()
    //{
    //    yield return new WaitForSeconds(2);
    //}
}