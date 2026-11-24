using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Request : MonoBehaviour
{
    private Button requestbutton;

    [SerializeField] private ResponseType responseType;
    [SerializeField] private string emailName;
    [SerializeField] private string header;
    [TextArea(10, 20)] [SerializeField] private string requestMessage;
    [TextArea(10, 20)] [SerializeField] private string requestMessageWithHints;
    [SerializeField] public int index = 0;
    [SerializeField] public float waitTime;

     private TextMeshProUGUI nameText;
     private TextMeshProUGUI subHeader;

    public ResponseType Type => responseType;
    public string EmailName => emailName;
    public string Header => header;
    public string RequestMessage => requestMessage;
    public string RequestMessageWithHints => requestMessageWithHints;
    public int Index => index;
    public float WaitTime => waitTime;

    public bool hasResponded { get; set; }
    public bool hasBeenCompleted { get; set; }
    
    private Sprite profileImage;
    private Image profile;

    private void OnEnable()
    {
        profileImage = Resources.Load<Sprite>("Sprites/Profile/" + emailName + " Icon");
        profile = transform.Find("Profile").gameObject.GetComponent<Image>();
        if (profile != null || profileImage != null)
        {
            profile.sprite = profileImage;
            profile.color = Color.white;
        }

        nameText = transform.Find("Info/Name").GetComponent<TextMeshProUGUI>();
        nameText.text = EmailName;
        subHeader = transform.Find("Info/SubHeader").GetComponent<TextMeshProUGUI>();
        subHeader.text = Header;
        requestbutton = GetComponent<Button>();

        requestbutton.onClick.AddListener(SelectionRequest);
        EventManager.OnFontSizeUpdate += OnFontChangeSize;
    }

    public void SelectionRequest()
    {
        if (WindowManager.instance.isMenuToggle)
            GameManager.instance.CloseMenu();
        
        if (EmailAndRequestManager.instance != null)
            EmailAndRequestManager.instance.SelectedRequest(this);
    }

    private void OnFontChangeSize()
    {
        if (GameManager.instance.fontSize > 35) return;
        nameText.fontSize = GameManager.instance.fontSize;
        if (GameManager.instance.fontSize > 25)
        {
            subHeader.gameObject.SetActive(false);
        }
        else
        {
            subHeader.gameObject.SetActive(true);
        }

        subHeader.fontSize = GameManager.instance.fontSize / 2;
    }

    private void OnDisable()
    {
        requestbutton.onClick.RemoveListener(SelectionRequest);
    }
}