using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Smile : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent onClick = new UnityEvent();

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick.Invoke();
    }
}
