using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    
[SerializeField] RectTransform dragRectTransform;
[SerializeField] Canvas canvas;
    public void OnDrag(PointerEventData eventData)
    {
       dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        WindowManager.instance.WindowBounds(dragRectTransform);
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
       dragRectTransform.SetAsLastSibling();
    }
}
