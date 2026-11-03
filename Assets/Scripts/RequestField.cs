using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RequestField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI requestTitle;
    [SerializeField] private TextMeshProUGUI textField;

    [SerializeField] private GameObject responseField;

    [SerializeField] private ScrollRect  scrollbar;
    private void OnEnable()
    {
        EventManager.OnRequestUpdate += UpdateRequest;
        EventManager.OnFontSizeUpdate += UpdateFontSize;
    }

    
    private void UpdateRequest(string requestMessage, string requestHeader, ResponseType type)
    {
        requestTitle.text = requestHeader;
        textField.text = requestMessage;
        scrollbar.verticalNormalizedPosition = 1f;
        UpdateFontSize();
    }
    
    private void UpdateFontSize()
    {
        requestTitle.fontSize = GameManager.instance.fontSize * 1.5f;
        textField.fontSize = GameManager.instance.fontSize;
    }
    
    private void OnDisable()
    {
        EventManager.OnRequestUpdate -= UpdateRequest;
    }
}