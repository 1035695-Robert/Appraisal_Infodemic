using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ForwardClickToWindow : MonoBehaviour, IPointerDownHandler
{
    private WindowClicked parentWindow;

    private void Awake()
    {
        parentWindow = GetComponentInParent<WindowClicked>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (parentWindow != null)
            parentWindow.OnPointerDown(eventData);
    }
}