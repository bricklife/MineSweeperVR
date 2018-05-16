using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    public bool isGazeOver;
    
    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_InteractiveItem.OnUp += HandleOver;
        m_InteractiveItem.OnDown += HandleClick;
    }
    
    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnUp -= HandleOver;
        m_InteractiveItem.OnDown -= HandleClick;
    }
    
    private void HandleOver()
    {
        isGazeOver = true;
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
    
    private void HandleOut()
    {
        isGazeOver = false;
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
    
    private void HandleClick()
    {
        isGazeOver = true;
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
