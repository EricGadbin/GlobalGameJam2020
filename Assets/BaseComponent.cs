using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseComponent : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap = null;
    bool hit = false;
    [SerializeField]
    Color hitColor = Color.red;
    [SerializeField]
    float timer = 0.2f;
    float _timer = 0.2f;

    private void Start() {
        _timer = 0;
    }

    private void Update() {
        if (hit) {
            if (_timer < timer) {
                _timer += Time.deltaTime;
                tilemap.color = new Color(Mathf.Lerp(Color.red.r, Color.white.r, _timer / timer), Mathf.Lerp(Color.red.g, Color.white.g, _timer / timer), Mathf.Lerp(Color.red.b, Color.white.b, _timer / timer));
            } else {
                // Debug.Log("color DONE");
                hit = false;
                _timer = 0;
                tilemap.color = Color.white;
            }
        }
    }

    public void GetHit()
    {
        hit = true;
        _timer = 0;
        tilemap.color = hitColor;
    }
}
