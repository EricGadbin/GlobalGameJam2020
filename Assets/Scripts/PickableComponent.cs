using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum IPickableObject
{
    ROBOT,
    ROBOT_LEG,
    ROBOT_ARM,
    ROBOT_BODY,
    ROBOT_HEAD
}

[System.Serializable]
public class SlotEvent : UnityEvent<GameObject>
{
}

public class PickableComponent : MonoBehaviour
{
    [SerializeField]
    private IPickableObject type;
    public IPickableObject Type {
        get {return type;}
    }

    private SlotComponent slot;
    [SerializeField]
    private UnityEvent OnPicked = new UnityEvent();
    [SerializeField]
    public SlotEvent OnDropped = new SlotEvent();
    
    public void GetPicked()
    {
        OnPicked.Invoke();
        slot = null;
    }

    public void GetDropped(SlotComponent newSlot)
    {
        slot = newSlot;
        GameObject tmp = slot.gameObject;
        Debug.Log("Before error : " + !!tmp);
        OnDropped.Invoke(tmp);
        Debug.Log("after error : " + !!tmp);
    }

    public SlotComponent GetSlot()
    {
        return slot;
    }
}
