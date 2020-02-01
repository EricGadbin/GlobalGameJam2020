using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityEventPickable : UnityEvent<PickableComponent>
{

}

public class InputComponent : MonoBehaviour
{
    public UnityEventPickable OnPickableIn = new UnityEventPickable();
    // Start is called before the first frame update
    public void input(PickableComponent obj) {
        OnPickableIn.Invoke(obj);
    }
}
