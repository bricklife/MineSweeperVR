using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var camera = Camera.main.gameObject;
        var y = camera.transform.eulerAngles.y;
        gameObject.transform.rotation = Quaternion.Euler(0, y, 0);
    }
}
