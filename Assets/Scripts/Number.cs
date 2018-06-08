using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    public Sprite[] sprites;

    public void Show(int number)
    {
        if (number > 0 && number < sprites.Length)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[number];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
