using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler
{
    
[SerializeField] RectTransform dragRectTransform;
[SerializeField] Canvas canvas;

    public void OnDrag(PointerEventData eventData)
    {
        if (WindowManager.instance.isMenuToggle) return;
       dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        WindowManager.instance.WindowBounds(dragRectTransform);
    }
}
