using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootComponent : MonoBehaviour
{
    [SerializeField]
    private GameObject lootAsset = null;
    [SerializeField]
    private int minLoot = 1;
    [SerializeField]
    private int maxLoot = 3;
    private float EjectionForce = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loot()
    {
        int amount = Random.Range(minLoot, maxLoot);
        GameObject tmp = null;
        for (int i = 0; i != amount; i++) {
            tmp = Instantiate(lootAsset, transform.position, transform.rotation);
            if (tmp) {
                Vector2 direction = new Vector2(Random.Range(-10, 10),Random.Range(-10, 10)).normalized;
                tmp.GetComponent<Rigidbody2D>().AddForce(direction * EjectionForce);
            }
        }
    }
}
