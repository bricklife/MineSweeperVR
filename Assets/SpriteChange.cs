using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour {

    public Sprite[] sprites;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show(int number)
    {
        if (number > 0 && number < sprites.Length) {
            GetComponent<SpriteRenderer>().sprite = sprites[number];
        } else {
            GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
