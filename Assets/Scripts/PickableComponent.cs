using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IPickableObject
{
    ROBOT_LEG,
    ROBOT_ARM,
    ROBOT_BODY,
    ROBOT_HEAD
}

public class PickableComponent : MonoBehaviour
{
    [SerializeField]
    private IPickableObject type;
    public IPickableObject Type {
        get {return type;}
    }

    private SlotComponent slot;

    public void GetPicked()
    {
        slot = null;
    }

    public void GetDropped(SlotComponent newSlot)
    {
        slot = newSlot;
    }
}
