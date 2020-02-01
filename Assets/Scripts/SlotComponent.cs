using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotComponent : MonoBehaviour
{
    [SerializeField]
    private List<IPickableObject> allowedObjects = new List<IPickableObject>(1);
    private PickableComponent stockedObject = null;

    public bool TryDrop(PickableComponent toStock) {
        if (stockedObject || !allowedObjects.Contains(toStock.Type))
            return false;
        stockedObject = toStock;
        stockedObject.transform.parent = transform;
        stockedObject.transform.position = transform.position;
        //maybe event
        return true;
    }
    public PickableComponent TryPick() {
        //maybe event
        PickableComponent tmp = stockedObject;

        stockedObject = null;
        return tmp;
    }
}
