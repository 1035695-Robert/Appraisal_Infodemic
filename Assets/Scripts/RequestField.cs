using System;
using TMPro;
using UnityEngine;

public class RequestField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI requestTitle;
    [SerializeField] private TextMeshProUGUI textField;

    private void OnEnable()
    {
        EventManager.OnRequestUpdate += UpdateRequest;
        EventManager.OnFontSizeUpdate += UpdateFontSize;
    }

    
    private void UpdateRequest(string requestMessage, string requestHeader, bool isRequest)
    {
        requestTitle.text = requestHeader;
        textField.text = requestMessage;
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