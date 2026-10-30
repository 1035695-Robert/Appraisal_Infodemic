using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OpenWindow : MonoBehaviour
{
    private Button tabButton;
   [SerializeField] private string targetName;


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
       WindowManager.instance.OpenWindow(targetName);
    }
}