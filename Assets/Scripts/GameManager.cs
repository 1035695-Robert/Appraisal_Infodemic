using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    [SerializeField] private Button settingButton;
    [SerializeField] private GameObject menuUI;
    
    [Header("Settings")] 
    public float fontSize;

    private void OnEnable()
    {
        settingButton.onClick.AddListener(ToggleMenu);
    }
    
    private void ToggleMenu()
    {
        if (menuUI != null)
        {
            menuUI.SetActive(!menuUI.activeSelf);
            menuUI.transform.SetAsLastSibling();
        }
    }

    private void OnDisable()
    {
        settingButton.onClick.RemoveListener(ToggleMenu);
    }
}

