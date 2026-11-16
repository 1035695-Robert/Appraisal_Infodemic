using System;
using TMPro;
using UnityEngine;

public enum ResponseType
{
    None,
    TrueInformation,
    Disinformation,
    Misinformation
}

public class EmailAndRequestManager : MonoBehaviour
{
    public static EmailAndRequestManager instance;
    [SerializeField] private Request _request;
    public Request ActiveRequest => _request;
    
 
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    private void OnEnable()
    {
        EventManager.OnToggleHints += () => SelectedRequest(ActiveRequest);
    }

    public void SelectedRequest(Request request)
    {
        
        _request = request;
        if (request == null) return;
        if (GameManager.instance.isToggleHints && !string.IsNullOrEmpty(ActiveRequest.RequestMessageWithHints))
            EventManager.OnRequestUpdate?.Invoke(
                ActiveRequest.RequestMessageWithHints,
                ActiveRequest.Header,
                ActiveRequest.Type);
        else
            EventManager.OnRequestUpdate?.Invoke(
                ActiveRequest.RequestMessage,
                ActiveRequest.Header,
                ActiveRequest.Type);


        if (ActiveRequest.Type == ResponseType.None)
        {
            WindowManager.instance.CloseWindow("Response Window");
            Debug.Log("this is an Email");
            if (!ActiveRequest.hasBeenCompleted)
            {
                NextRequest.instance.ChecktoSendEmails(ActiveRequest.Index, ActiveRequest.waitTime);
                ActiveRequest.hasBeenCompleted = true;
            }

            return;
        }

        if (ActiveRequest.hasResponded)
        {
            WindowManager.instance.CloseWindow("Response Window");
            return;
        }

        Debug.Log("open Response");
        WindowManager.instance.OpenResponseWindow("Response Window");
        Response.instance.responseType = ActiveRequest.Type;
        Response.instance.targetRequest = ActiveRequest;
    }
    //
    //

    //
}