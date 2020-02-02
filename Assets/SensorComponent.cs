using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SensorComponent : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> detectedEntities = new List<GameObject>();
    public UnityEvent OnSensorTriggered = new UnityEvent();

    /// <summary>
    /// This function is called when the behaviour becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        detectedEntities.Clear();
    }

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        detectedEntities.Clear();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<TeamComponent>()) {
            detectedEntities.Add(other.gameObject);
            //Debug.Log(other.name + "Entered sensor of " + transform.parent.name);
            OnSensorTriggered.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<TeamComponent>()) {
            detectedEntities.Remove(other.gameObject);
            //Debug.Log(other.name + "Exited sensor of " + transform.parent.name);
            OnSensorTriggered.Invoke();
        }
    }
}
