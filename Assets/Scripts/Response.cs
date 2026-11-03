using System;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;

public class Response : MonoBehaviour
{
    public static Response instance;
    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    
    
    [SerializeField] private Button trueInformation;
    [SerializeField] private Button misinformation;
    [SerializeField] private Button disinformation;

    public Request targetRequest;
    
    public ResponseType responseType;
    
    private void OnEnable()
    {
        trueInformation.onClick.AddListener(() => SelectedResponse(ResponseType.TrueInformation));
        misinformation.onClick.AddListener(() => SelectedResponse(ResponseType.Misinformation));
        disinformation.onClick.AddListener(() => SelectedResponse(ResponseType.Disinformation));
    }

    private void SelectedResponse(ResponseType  responseSelected)
    {
        if (responseSelected == responseType) Correct();
        else Incorrect();
    }
    
    private void Correct()
    {
      Debug.Log("correct");
      targetRequest.hasResponded =  true;
      gameObject.SetActive(false);
    }

    private void Incorrect()
    {
        Debug.Log("incorrect");
        targetRequest.hasResponded =  true;
        gameObject.SetActive(false);   }

    private void OnDisable()
    {
        trueInformation.onClick.RemoveAllListeners();
        misinformation.onClick.RemoveAllListeners();
        disinformation.onClick.RemoveAllListeners();
    }
}