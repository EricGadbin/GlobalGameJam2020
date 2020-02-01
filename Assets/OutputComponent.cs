using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputComponent : MonoBehaviour
{
    [SerializeField] private GameObject dest = null;
    // Start is called before the first frame update
    public void output(PickableComponent obj){
        dest.GetComponent<InputComponent>().input(obj);
    }
}
