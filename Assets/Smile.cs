using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Smile : MonoBehaviour
{
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    public bool isGazeOver;

    public Field field;

    private void OnEnable()
    {
        m_InteractiveItem.OnUp += HandleUp;
    }

    private void OnDisable()
    {
        m_InteractiveItem.OnUp -= HandleUp;
    }

    private void HandleUp()
    {
        field.ResetField();
    }
}