using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            GetComponent<HealthComponent>().GetDamages(110);
    }

    public void QuandJaMouru()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
