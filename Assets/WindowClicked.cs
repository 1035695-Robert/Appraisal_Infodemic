using UnityEngine;
using UnityEngine.EventSystems;

public class WindowClicked : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] RectTransform dragRectTransform;

    public void OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetAsLastSibling();
    }
}
