using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public GameObject cube;
    public GameObject bomb;
    public GameObject number;

    public Vector3 center = new Vector3(0f, 0, 0);
    public int width = 90;
    public int height = 10;
    public float r = 20;
    public float scale = 0.98f;
    public float rate = 0.1f;

    private float size;
    private float angle;

    private bool[,] bombs;

    // Use this for initialization
    void Start()
    {
        size = Mathf.PI * r * 2 / width;
        angle = 360 / width;

        InitBombs();

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Add(cube, x, y);

                if (Random.value < rate)
                {
                    Add(bomb, x, y);
                    SetBomb(x, y);
                }
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var n = GetNumOfBombs(x, y);
                if (!IsBomb(x, y) && n > 0 && n < 9)
                {
                    var num = Add(number, x, y);
                    num.GetComponent<SpriteChange>().Show(n);
                }
            }
        }
    }

    private void InitBombs()
    {
        bombs = new bool[width, height];
    }

    private void SetBomb(int x, int y)
    {
        bombs[x, y] = true;
    }

    private bool IsBomb(int x, int y)
    {
        if (y < 0 || y >= height)
        {
            return false;
        }
        if (x < 0)
        {
            x += width;
        }
        if (x >= width)
        {
            x -= width;
        }
        return bombs[x, y];
    }

    private int GetNumOfBombs(int x, int y)
    {
        var num = 0;
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                num += IsBomb(i, j) ? 1 : 0;
            }

        }
        return num;
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
