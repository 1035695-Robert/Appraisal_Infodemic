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
    }

    private void OnEnable()
    {
        requestbutton.onClick.AddListener(SelectedRequest);
    }

    public void SelectedRequest()
    {
        string requestheader = requestTitle.text;
        EventManager.OnRequestUpdate?.Invoke(requestMessage,requestheader,isRequest);
    }

    private void OnDisable()
    {
        requestbutton.onClick.RemoveListener(SelectedRequest);
    }
}