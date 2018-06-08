using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Cube : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{
    public UnityEvent onClick = new UnityEvent();

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onClick.Invoke();
    }
}
