﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandComponent : MonoBehaviour
{
    [SerializeField]
    private float detectionRadius = 0.5f;

    private PickableComponent heldObject = null;

    void DropObject(SlotComponent slot)
    {
        if (slot.TryDrop(heldObject)) {
            heldObject = null;
        }
    }

    void PickObject(PickableComponent pickable)
    {
        heldObject = pickable;
        heldObject.transform.parent = transform;
        heldObject.transform.position = transform.position;
    }

    bool CheckForSlot()
    {
        Collider2D []colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (Collider2D collider in colliders)
        {
            SlotComponent slot = collider.GetComponent<SlotComponent>();
            if (slot) {
                if (heldObject) {
                    DropObject(slot);
                } else {
                    PickableComponent pickable = slot.TryPick();
                    if (pickable)
                        PickObject(pickable);
                }
                return true;
            }
        }
        return false;
    }

    bool CheckForPickable()
    {
        Collider2D []colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (Collider2D collider in colliders)
        {
            PickableComponent pickable = collider.GetComponent<PickableComponent>();
            if (pickable) {
                if (!heldObject) {
                    PickObject(pickable);
                }
                return true;
            }
        }
        return false;
    }

    public void SeekForObject()
    {
        Debug.Log("Try action ..");
        //Check si y'a un slot
            //si oui Check si on a un pickable
                //Si oui, essayez de le poser
                //Si non, Check si le slot est plein
                    //Si oui, essayez de le prendre
        //Sinon, check si y'a un pickable,
            //si oui, check si on a un pickable en main
                //si non, ramasser le pickable

        if (!CheckForSlot()) {
            if (CheckForPickable()) {
                Debug.Log("Pickable detected");
            }
        } else {
            Debug.Log("Slot detected");
        }
    }

    private void OnDrawGizmos() {
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, detectionRadius);
    }
}
