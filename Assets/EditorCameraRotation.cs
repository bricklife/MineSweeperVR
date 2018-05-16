using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorCameraRotation : MonoBehaviour
{
    void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, 1, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0, -1, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Rotate(-1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Rotate(1, 0, 0);
        }
        #endif
    }
}
