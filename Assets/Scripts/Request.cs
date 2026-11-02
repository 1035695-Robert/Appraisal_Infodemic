using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public enum ResponseType
{
    None,
    TrueInformation,
    Disinformation,
    Misinformation
}

public class Request : MonoBehaviour
{
    private Button requestbutton;

    [SerializeField] private ResponseType responseType;
    [SerializeField] private string emailName;
    [SerializeField] private string header;
    [TextArea(10, 20)] [SerializeField] private string requestMessage;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI requestTitle;
    
    [SerializeField] private float waitTime;
    [SerializeField] private GameObject[] nextEmails;


    private void Awake()
    {
        nameText.text = emailName;
        requestTitle.text = header;
        requestbutton = GetComponent<Button>();
    }

    private void OnEnable()
    {
        requestbutton.onClick.AddListener(SelectedRequest);
        EventManager.OnFontSizeUpdate += OnFontChangeSize;
    }

    public void SelectedRequest()
    {
        string requestheader = requestTitle.text;
        EventManager.OnRequestUpdate?.Invoke(requestMessage, requestheader, responseType);
        if (responseType == ResponseType.None)
        {
            WindowManager.instance.CloseWindow("Response Window");
            StartCoroutine(DelayForNextEmail());
            return;
        }

        Debug.Log("open Response");
        WindowManager.instance.OpenResponseWindow("Response Window");

        StartCoroutine(DelayForNextEmail());
    }

    private IEnumerator DelayForNextEmail()
    {
        float wait = waitTime;
        Debug.Log(emailName);
        yield return new WaitForSeconds(wait);
        foreach (GameObject email in nextEmails)
        {
            email.SetActive(true);
        }

        yield return null;
    }


    private void OnFontChangeSize()
    {
        if (GameManager.instance.fontSize > 35) return;
        nameText.fontSize = GameManager.instance.fontSize;
        if (GameManager.instance.fontSize > 25)
        {
            requestTitle.gameObject.SetActive(false);
        }
        else
        {
            requestTitle.gameObject.SetActive(true);
        }

        requestTitle.fontSize = GameManager.instance.fontSize / 2;
    }

    private void OnDisable()
    {
        requestbutton.onClick.RemoveListener(SelectedRequest);
    }
}