using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class WindowManager : MonoBehaviour
{
    public static WindowManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

   

    #region Toggle Window State

    [SerializeField] private GameObject windowObject;
    [SerializeField] private List<GameObject> windows;
    void Start()
    {
        foreach (Transform window in windowObject.transform)
        {
            windows.Add(window.gameObject);
        }
    }
    public void OpenWindow(string windowName)
    {
        Debug.Log(windowName);
        GameObject targetWindow = GetWindow(windowName);
        if (!targetWindow.activeSelf)
        {
            targetWindow.SetActive(true);
        }
        else if (targetWindow.transform.GetSiblingIndex() == windowObject.transform.childCount - 1)
        {
            CloseWindow(targetWindow.name);
            return;
        }

        targetWindow.transform.SetAsLastSibling();
    }

    public void CloseWindow(string WindowName)
    {
        GameObject targetWindow = GetWindow(WindowName);
        targetWindow.transform.SetAsFirstSibling();
        targetWindow.SetActive(false);
    }

    public void OpenResponseWindow(string responseWindow)
    {
        GameObject targetWindow = GetWindow(responseWindow);
        if (targetWindow.activeInHierarchy) return;
        targetWindow.SetActive(true);
    }

    private GameObject GetWindow(string windowName)
    {
        GameObject targetWindow = windows.Find(window => window.name == windowName);
        return targetWindow;
    }

    #endregion

    [SerializeField] private RectTransform windowViewRect;
    private RectTransform _currentDragWindow;
    [SerializeField] private float padding = 0f;

    public void WindowBounds(RectTransform windowRect)
    {
        if (_currentDragWindow == null || _currentDragWindow != windowRect)
            _currentDragWindow = windowRect;

        float halfWidth = windowViewRect.rect.width / 2;
        float halfHeight = windowViewRect.rect.height / 2;

        float halfWindowWidth = _currentDragWindow.rect.width / 2;
        float halfWindowHeight = _currentDragWindow.rect.height / 2;

        float minX = -halfWidth + halfWindowWidth + padding;
        float maxX = halfWidth - halfWindowWidth -padding;

        float minY = -halfHeight + halfWindowHeight + padding;
        float maxY = halfHeight - halfWindowHeight - padding;

        Vector2 currentPos = windowRect.anchoredPosition;

        float clampedX = Mathf.Clamp(currentPos.x, minX, maxX);
        float clampedY = Mathf.Clamp(currentPos.y, minY, maxY);

        _currentDragWindow.anchoredPosition = new Vector2(clampedX, clampedY);
    }
}