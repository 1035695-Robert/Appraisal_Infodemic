using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OpenWindow : MonoBehaviour
{
    private Button tabButton;
    public GameObject targetWindow;
    public GameObject windows;


    private void OnEnable()
    {
        tabButton = GetComponent<Button>();
        tabButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        tabButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (!targetWindow.activeSelf)
            targetWindow.SetActive(true);
        else if (targetWindow.transform.GetSiblingIndex() == windows.transform.childCount - 1)
            targetWindow.SetActive(false);

        targetWindow.transform.SetAsLastSibling();
    }
}