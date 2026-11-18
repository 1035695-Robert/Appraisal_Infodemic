using System;
using UnityEngine;
using UnityEngine.EventSystems;
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

    public bool isToggleHints = false;

    [Header("Settings")] public float fontSize;

    private void OnEnable()
    {
        settingButton.onClick.AddListener(ToggleMenu);
    }

    private void ToggleMenu()
    {
        if (menuUI != null)
        {
            bool status = !menuUI.activeSelf;
            menuUI.SetActive(WindowManager.instance.isMenuToggle = status);
            menuUI.transform.SetAsLastSibling();
        }
    }
    public void CloseMenu()
    {
        menuUI.SetActive(WindowManager.instance.isMenuToggle = false);
    }
    
    private void OnDisable()
    {
        settingButton.onClick.RemoveListener(ToggleMenu);
    }

   
}