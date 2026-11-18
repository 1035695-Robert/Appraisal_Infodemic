using UnityEngine;
using UnityEngine.EventSystems;

public class CloseMenu : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private RectTransform menuRectTransform;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!WindowManager.instance.isMenuToggle) return;
        if (!RectTransformUtility.RectangleContainsScreenPoint(
                menuRectTransform, eventData.position, eventData.pressEventCamera))
        {
            GameManager.instance.CloseMenu();
        }
    }
}
