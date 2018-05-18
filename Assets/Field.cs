using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public GameObject cube;
    public GameObject bomb;

    public Vector3 center = new Vector3(0f, 0, 0);
    public int width = 90;
    public int height = 10;
    public float r = 10;
    public float scale = 0.98f;

    private float size = 0;
    private float angle = 0;

    // Use this for initialization
    void Start()
    {
        size = Mathf.PI * r * 2 / width;
        angle = 360 / width;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Add(cube, x, y);
                if (Random.value < 0.3) {
                    Add(bomb, x, y);
                }
            }
        }
    }

    private GameObject Add(GameObject target, int x, int y)
    {
        var obj = Instantiate(target, new Vector3(0f, (y - height / 2) * size, r + size / 2), Quaternion.identity);

        obj.transform.RotateAround(center, Vector3.up, angle * x);
        obj.transform.localScale = new Vector3(size * scale, size * scale, size * scale);
        obj.transform.parent = gameObject.transform;

        return obj;
    }

    // Update is called once per frame
    void Update()
    {
        //var rotY = Quaternion.AngleAxis(45.0f * Time.deltaTime, Vector3.up);
        //transform.rotation *= rotY;
    }
}
