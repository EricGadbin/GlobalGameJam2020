using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ConveyorComponent : MonoBehaviour
{
    // Start is called before the first frame update
    private PickableComponent conveyed = null;
    private bool isRunning = false;
    [SerializeField]
    private Transform dest = null;
    private float speed = 2f;
    void Start()
    {
        GetComponent<InputComponent>().OnPickableIn.AddListener(startConvey);
    }

    public void startConvey(PickableComponent toConvey)
    {
        Debug.Log("conveying");
        conveyed = toConvey;
        isRunning = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
            return;
        conveyed.gameObject.transform.position = Vector3.MoveTowards(conveyed.transform.position, dest.position, speed * Time.deltaTime);
        if (Vector3.Distance(conveyed.transform.position, dest.position) <= 0) {
            isRunning = false;
            GetComponent<OutputComponent>().output(conveyed);
            conveyed = null;
        }

    }
}
