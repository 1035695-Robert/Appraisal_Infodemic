using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Request : MonoBehaviour
{
    private Button requestbutton;

    [SerializeField] private bool isRequest;

    [SerializeField] private string emailName;
    [SerializeField] private string header;
    [TextArea(10, 20)] [SerializeField] private string requestMessage;
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI requestTitle;


    private void Awake()
    {
        nameText.text = emailName;
        requestTitle.text = header;
        requestbutton = GetComponent<Button>();
        OnFontChangeSize();
    }

    private void OnEnable()
    {
        requestbutton.onClick.AddListener(SelectedRequest);
        EventManager.OnFontSizeUpdate += OnFontChangeSize;
    }

 

    public void SelectedRequest()
    {
        string requestheader = requestTitle.text;
        EventManager.OnRequestUpdate?.Invoke(requestMessage,requestheader,isRequest);
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
            requestTitle.gameObject.SetActive(true);}
        requestTitle.fontSize = GameManager.instance.fontSize/2;
       }

    private void OnDisable()
    {
        requestbutton.onClick.RemoveListener(SelectedRequest);
    }
}