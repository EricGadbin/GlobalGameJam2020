using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashComponent : SlotComponent
{
    // Start is called before the first frame update
    override public bool TryDrop(PickableComponent toStock)
    {
        Destroy(toStock.gameObject);
        return true;
    }
    override public PickableComponent TryPick() {
        return null;
    }
}
