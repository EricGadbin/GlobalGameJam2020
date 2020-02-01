using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotComponent : MonoBehaviour
{
    [SerializeField]
    private List<IPickableObject> allowedObjects = new List<IPickableObject>(1);
    [SerializeField]
    protected PickableComponent stockedObject = null;

    void Start() {
        if (GetComponent<InputComponent>()) {
            GetComponent<InputComponent>().OnPickableIn.AddListener(inputDrop);
        }
    }
    void inputDrop(PickableComponent tmp) {
        if (TryDrop(tmp))
            return;
        if (GetComponent<OutputComponent>())
            GetComponent<OutputComponent>().output(tmp);
        else
            Destroy(tmp.gameObject);
    }
    virtual public bool TryDrop(PickableComponent toStock) {
        Debug.Log("TryDrop");
        if (stockedObject || !allowedObjects.Contains(toStock.Type))
            return false;
        Debug.Log("TryDrop success");
        stockedObject = toStock;
        stockedObject.transform.parent = transform;
        stockedObject.transform.position = transform.position;
        //maybe event
        return true;
    }
    virtual public PickableComponent TryPick() {
        //maybe event
        PickableComponent tmp = stockedObject;

        stockedObject = null;
        return tmp;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
    }
}
