using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProgressComponent : MonoBehaviour
{
    [SerializeField]
    private Transform bar = null;
    private float filled = 0f;
    
    public void setFill(float fill) {
        bar.localScale = new Vector3(fill, 1f, 1f);
    }
}
