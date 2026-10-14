using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    
[SerializeField] RectTransform dragRectTransform;
[SerializeField] Canvas canvas;
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("drag");
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
       dragRectTransform.SetAsLastSibling();
    }
}
