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
            transform.Rotate(Vector3.up, 1, Space.World);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -1, Space.World);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right, -1, Space.Self);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right, 1, Space.Self);
        }
#endif
    }
}
