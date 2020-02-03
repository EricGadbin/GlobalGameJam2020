using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorReleaseComponent : SlotComponent
{
    [SerializeField]
    private Transform drop = null;

    override public bool TryDrop(PickableComponent toStock) {
        if (toStock.Type==IPickableObject.ROBOT_BODY && toStock.GetComponent<RobotBodyComponent>().IsFull()) {
            //StartCoroutine(waiting());
            toStock.transform.parent = null;
            toStock.transform.position = drop.position;
            toStock.transform.rotation = drop.rotation;
            toStock.GetComponent<RobotControllerComponent>().GetRepair();
            GetComponent<AudioSource>().Play();
            return true;
        }
        return false;
    }

    //IEnumerator waiting()
    //{
    //    yield return new WaitForSeconds(2);
    //}
}