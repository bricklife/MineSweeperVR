using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public GameObject cube;
    public GameObject bomb;
    public GameObject number;
    public GameObject smile;

    public GameObject ground;
    public GameObject ui;

    public int width = 90;
    public int height = 10;
    public int numOfBombs = 180;

    public Vector3 center = new Vector3(0f, 0, 0);
    public float r = 20f;
    public float scale = 0.98f;

    private float size;
    private float angle;

    private GameObject[,] cubes;
    private bool[,] bombs;
    private bool needsSetup = false;

    // Use this for initialization
    void Start()
    {
        ResetField();
    }

    public void ResetField()
    {
        cubes = new GameObject[width, height];
        bombs = new bool[width, height];

        foreach (Transform n in ground.transform)
        {
            Destroy(n.gameObject);
        }

        foreach (Transform n in ui.transform)
        {
            Destroy(n.gameObject);
        }

        size = Mathf.PI * r * 2 / width;
        angle = 360f / width;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var clickedX = x;
                var clickedY = y;
                var c = Add(cube, ground, x, y);
                c.GetComponent<Cube>().onClick.AddListener(() => Open(clickedX, clickedY));
                cubes[x, y] = c;
            }
        }

        ui.transform.rotation = Quaternion.identity;
        var s = Add(smile, ui, 0, height + 1);
        s.GetComponent<Smile>().onClick.AddListener(() => ResetField());
        var aim = s.transform.position - center;
        s.transform.rotation = Quaternion.LookRotation(aim);

        var camera = Camera.main.gameObject;
        ui.transform.rotation = Quaternion.Euler(0, camera.transform.eulerAngles.y, 0);

        needsSetup = true;
    }

    public void SetupFeild(int exX, int exY)
    {
        var restOfNum = numOfBombs;
        while (restOfNum > 0)
        {
            var x = Random.Range(0, width);
            var y = Random.Range(0, height);
            if (x == exX && y == exY)
            {
                continue;
            }
            if (IsBomb(x, y))
            {
                continue;
            }

            Add(bomb, ground, x, y);
            SetBomb(x, y);
            restOfNum--;
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                var n = GetNumOfBombs(x, y);
                if (!IsBomb(x, y) && n > 0 && n < 9)
                {
                    var num = Add(number, ground, x, y);
                    num.GetComponent<SpriteChange>().Show(n);
                }
            }
        }
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

    private GameObject Add(GameObject target, GameObject parent, int x, int y)
    {
        var obj = Instantiate(target, new Vector3(0f, (y - height / 2) * size, r + size / 2), Quaternion.identity);

        obj.transform.RotateAround(center, Vector3.up, angle * x);
        obj.transform.localScale = new Vector3(size * scale, size * scale, size * scale);
        obj.transform.parent = parent.transform;

        return obj;
    }

    private void OpenBombs()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (IsBomb(x, y))
                {
                    cubes[x, y].SetActive(false);
                }
            }
        }
    }

    public void Open(int x, int y)
    {
        if (IsBomb(x, y))
        {
            OpenBombs();
            return;
        }

        if (needsSetup)
        {
            SetupFeild(x, y);
            needsSetup = false;
        }

        if (y < 0 || y >= height)
        {
            return;
        }
        if (x < 0)
        {
            x += width;
        }
        if (x >= width)
        {
            x -= width;
        }

        var c = cubes[x, y];
        if (!c.activeSelf)
        {
            return;
        }

        c.SetActive(false);

        var num = GetNumOfBombs(x, y);
        if (num == 0)
        {
            Open(x - 1, y - 1);
            Open(x, y - 1);
            Open(x + 1, y - 1);

            Open(x - 1, y);
            Open(x + 1, y);

            Open(x - 1, y + 1);
            Open(x, y + 1);
            Open(x + 1, y + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //var rotY = Quaternion.AngleAxis(45.0f * Time.deltaTime, Vector3.up);
        //transform.rotation *= rotY;
    }
}
