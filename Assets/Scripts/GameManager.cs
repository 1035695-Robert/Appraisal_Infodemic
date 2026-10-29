using System;
using UnityEngine;
using UnityEngine.InputSystem;

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

    [Header("Settings")] 
    public float fontSize;
    
    
    [SerializeField] private GameObject menuUI;
    public void Update()
    {
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
            ToggleMenu();
    }
    

    private void ToggleMenu()
    {
        if (menuUI != null)
        {
            menuUI.SetActive(!menuUI.activeSelf);
        }
    }
    
}

