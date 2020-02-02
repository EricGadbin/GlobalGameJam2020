using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ScrapComponent : MonoBehaviour
{
    [SerializeField]
    private float MinSpeed = 2;
    private GameObject player = null;

    private int value = 1;
    [SerializeField]
    private float minDistEat = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    IEnumerator Caught()
    {
        player.GetComponent<MoneyComponent>().AddMoney(value);
        GetComponent<AudioSource>().Play();
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (player) {
            float dist = Vector3.Distance(player.transform.position, transform.position);
            float ratio = dist / MinSpeed;
            float speed = MinSpeed / ratio;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            if (dist <= minDistEat) {
                StartCoroutine("Caught");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && !player) {
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (player == other.gameObject) {
            player = null;
        }
    }
}
