using UnityEngine;
using UnityEngine.InputSystem;

public class ClickAndDrag : MonoBehaviour
{
    [SerializeField] private InputActionReference action;
    [SerializeField] private InputActionReference pointerPositionAction;

    [SerializeField] private RectTransform panelTransform;
    [SerializeField] private RectTransform canvasTransform;
    [SerializeField] private RectTransform headerTransform;

    [SerializeField] private Camera uiCamera;

    private Vector2 offset;
    private bool isDragging;

    private void OnEnable()
    {
        action.action.started += OnClickStart;
        action.action.canceled += OnClickCancel;
        pointerPositionAction.action.performed += OnPointMove;
    }
    private void OnDisable()
    {
        action.action.started -= OnClickStart;
        action.action.canceled -= OnClickCancel;
        pointerPositionAction.action.performed -= OnPointMove;
        isDragging = false;
    }

    private bool IsPointerOverHeader(Vector2 pointerPos)
    {
        return RectTransformUtility.RectangleContainsScreenPoint(headerTransform, pointerPos, uiCamera);
    }

    private void OnClickStart(InputAction.CallbackContext context)
    {
        Debug.Log("click");
        var pointerPos = pointerPositionAction.action.ReadValue<Vector2>();
        if(IsPointerOverHeader(pointerPos))
        {
            isDragging = true;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasTransform, pointerPos, uiCamera, 
            out var localPos
            );
            offset = panelTransform.anchoredPosition - localPos;
        }
    }

    private void OnClickCancel(InputAction.CallbackContext context)
    {
        isDragging = false;
    }

    private void OnPointMove(InputAction.CallbackContext context)
    {
        Debug.Log("drag");
        if (!isDragging) return;
        var pointerPos = context.ReadValue<Vector2>();
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasTransform, 
            pointerPos,
            uiCamera, 
            out var localPos
        );
        panelTransform.anchoredPosition = localPos +offset;
    }
}
