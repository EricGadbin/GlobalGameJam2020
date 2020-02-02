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
            if (j == 0) {
                if (legs)
                    Destroy(legs.gameObject);
                legs = null;
            }
            if (j == 1) {
                if (arms) {
                    Destroy(arms.gameObject);
                }
                arms = null;

            }
            if (j == 2) {
                if (head) {
                    Destroy(head.gameObject);
                }
                head = null;
            }
        }
        
        if (head)
            head.gameObject.SetActive(true);
        if (legs)
            legs.gameObject.SetActive(true);
        if (arms)
            arms.gameObject.SetActive(true);
        isFull = false;
    }

    public void Activate()
    {
        legs.GetComponent<Collider2D>().enabled = true;
        arms.GetComponent<Collider2D>().enabled = true;
        head.GetComponent<Collider2D>().enabled = true;
        head.gameObject.SetActive(false);
        legs.gameObject.SetActive(false);
        arms.gameObject.SetActive(false);
    }

    public bool IsFull() {
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
            legs.transform.rotation = transform.rotation;
            legs.GetComponent<Collider2D>().enabled = false;
            
            if (head && arms && legs) {
                CompleteRepair();
            }
            legs.GetDropped(this);
            return true;
        }
        if (!arms && toStock.Type == IPickableObject.ROBOT_ARM) {
            arms = toStock;
            arms.GetComponent<PickableComponent>().enabled = false;
            arms.transform.parent = transform;
            arms.transform.position = transform.position;
            arms.transform.rotation = transform.rotation;
            arms.GetComponent<Collider2D>().enabled = false;

            if (head && arms && legs) {
                CompleteRepair();
            }
            arms.GetDropped(this);
            return true;
        }
        if (!head && toStock.Type == IPickableObject.ROBOT_HEAD) {
            head = toStock;
            head.GetComponent<PickableComponent>().enabled = false;
            head.transform.parent = transform;
            head.transform.position = transform.position;
            head.transform.rotation = transform.rotation;
            head.GetComponent<Collider2D>().enabled = false;
            if (head && arms && legs) {
                CompleteRepair();
            }
            head.GetDropped(this);
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
