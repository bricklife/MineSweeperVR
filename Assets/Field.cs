using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public GameObject cube;
    public GameObject bomb;

    static Vector3 center = new Vector3(0f, 0, 0);
    static int num = 90;
    static float r = 10;
    static float size = Mathf.PI * r * 2 / num;
    static float angle = 360 / num;
    static float scale = 0.98f;

    // Use this for initialization
    void Start()
    {
        for (int y = -10; y <= 10; y++)
        {
            for (int x = 0; x < num; x++)
            {
                Add(cube, x, y);
                Add(bomb, x, y);
            }
        }
    }

    void Add(GameObject target, int x, int y)
    {
        var obj = Instantiate(target, new Vector3(0f, y * size, r + size / 2), Quaternion.identity);
        obj.transform.RotateAround(center, Vector3.up, angle * x);
        obj.transform.localScale = new Vector3(size * scale, size * scale, size * scale);
        obj.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //var rotY = Quaternion.AngleAxis(45.0f * Time.deltaTime, Vector3.up);
        //transform.rotation *= rotY;
    }
}
