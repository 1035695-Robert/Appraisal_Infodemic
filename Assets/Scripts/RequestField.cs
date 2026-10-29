using System;
using TMPro;
using UnityEngine;

public class RequestField : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI requestTitle;
    [SerializeField] private TextMeshProUGUI textField;

    [SerializeField] private GameObject responseField;

    private void OnEnable()
    {
        EventManager.OnRequestUpdate += UpdateRequest;
        EventManager.OnFontSizeUpdate += UpdateFontSize;
    }

    
    private void UpdateRequest(string requestMessage, string requestHeader, ResponseType type)
    {
        requestTitle.text = requestHeader;
        textField.text = requestMessage;
        UpdateFontSize();
        if (type == ResponseType.None) return;
        ToggleResponseField();
    }

    private void ToggleResponseField()
    {
        responseField.SetActive(!responseField.activeSelf);
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