using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    [SerializeField] private GameObject robot = null;
    [SerializeField] private float spawnTime = 5f;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        GameObject tmp = null;
        timer += Time.deltaTime;
        if (timer >= spawnTime) {
            timer = 0f;
            tmp = Instantiate(robot, transform.position, transform.rotation);
            GetComponent<OutputComponent>().output(tmp.GetComponent<PickableComponent>());
        }
    }
}
