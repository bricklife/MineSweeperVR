using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    void Update()
    {
        var camera = Camera.main.gameObject;
        var y = camera.transform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, y, 0);
    }
}
