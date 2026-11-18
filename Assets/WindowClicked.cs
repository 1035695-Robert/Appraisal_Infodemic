using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowClicked : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] RectTransform dragRectTransform;

    private void OnEnable()
    {
        dragRectTransform = gameObject.GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (WindowManager.instance.isMenuToggle) GameManager.instance.CloseMenu();
        dragRectTransform.SetAsLastSibling();
    }
}
