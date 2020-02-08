using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorComponent : MonoBehaviour
{
    public void ChangeColor(bool RedWon)
    {
        GetComponent<Image>().color = RedWon ? Color.red : Color.blue;
    }
}
