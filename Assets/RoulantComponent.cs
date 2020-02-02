using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoulantComponent : MonoBehaviour
{
    [SerializeField] Transform from = null;
    [SerializeField] Transform to = null;
    private float speed = 2f;


    [SerializeField]
    // Start is called before the first frame update

    void Start()
    {
        GetComponent<InputComponent>().OnPickableIn.AddListener(addItem);
    }

    void addItem(PickableComponent newItem)
    {
        newItem.transform.parent = gameObject.transform;
        newItem.transform.position = from.position;
    }

    // Update is called once per frame
    void Update()
    {
        Transform item = null;
        for (int i = 0; i < transform.childCount ; i += 1) {
            item = transform.GetChild(i);
            if (item == to || item == from || item.name == "border")
                continue;
            item.transform.position = Vector3.MoveTowards(item.transform.position, to.position, speed * Time.deltaTime);
            if (Vector3.Distance(item.transform.position, to.position) <= 0.1f) {
                Destroy(item.gameObject);
            }
        }
    }
}
