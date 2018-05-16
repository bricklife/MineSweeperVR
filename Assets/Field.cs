using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{

    public GameObject cube;
    public GameObject bomb;

    // Use this for initialization
    void Start()
    {
        var center = new Vector3(0f, 0, 0);
        var num = 90;
        var r = 10;
        var size = Mathf.PI * r * 2 / num;
        var angle = 360 / num;
        var scale = 0.98f;

        for (int y = -10; y <= 10; y++)
        {
            for (int i = 0; i < num; i++)
            {

                foreach (var item in new GameObject[] {cube, bomb})
                {
                    var obj = Instantiate(item, new Vector3(0f, y * size, r + size / 2), Quaternion.identity);
                    obj.transform.RotateAround(center, Vector3.up, angle * i);
                    obj.transform.localScale = new Vector3(size * scale, size * scale, size * scale);
                    obj.transform.parent = transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //var rotY = Quaternion.AngleAxis(45.0f * Time.deltaTime, Vector3.up);
        //transform.rotation *= rotY;
    }
}
