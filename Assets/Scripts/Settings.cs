using System;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField] private Button fontIncrease;
    [SerializeField] private Button fontDecrease;
    [SerializeField] private int changeValue;

    [SerializeField] private Button hintsButton;
    [SerializeField] private TextMeshProUGUI hintsText;
    
    [SerializeField] Button powerButton;

    public bool toggleHints;


    void Start()
    {
        _gameManager = GameManager.instance;
        if (_gameManager == null)
        {
            Debug.LogError("No GameManager found");
        }
    }

    private void OnEnable()
    {
        fontIncrease.onClick.AddListener(() => FontSizeChange(+changeValue));
        fontDecrease.onClick.AddListener(() => FontSizeChange(-changeValue));

        hintsButton.onClick.AddListener(HintsToggle);
        
        powerButton.onClick.AddListener(PowerButton);
    }

    private void FontSizeChange(int value)
    {
        _gameManager.fontSize += value;
        if (_gameManager.fontSize > 35) _gameManager.fontSize = 35;
        if (_gameManager.fontSize < 15) _gameManager.fontSize = 15;
        EventManager.OnFontSizeUpdate?.Invoke();
    }

    private void HintsToggle()
    {
        Debug.Log("hints toggle");
        hintsText.text = GameManager.instance.isToggleHints ? "Hints : OFF" : "Hints : ON";
        GameManager.instance.isToggleHints = !GameManager.instance.isToggleHints;
        EventManager.OnToggleHints?.Invoke();
    }

    private void PowerButton()
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        fontIncrease.onClick.RemoveAllListeners();
        fontDecrease.onClick.RemoveAllListeners();
        hintsButton.onClick.AddListener(HintsToggle);
        powerButton.onClick.AddListener(PowerButton);
    }
}