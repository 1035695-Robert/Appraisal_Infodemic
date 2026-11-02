using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private GameManager _gameManager;

    [SerializeField] private Button fontIncrease;
    [SerializeField] private Button fontDecrease;
    [SerializeField] private int changeValue;

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
    }

    private void FontSizeChange(int value)
    {
        _gameManager.fontSize += value;
        if (_gameManager.fontSize > 35) _gameManager.fontSize = 35;
        if (_gameManager.fontSize < 15) _gameManager.fontSize = 15;
        EventManager.OnFontSizeUpdate?.Invoke();
    }

    private void OnDisable()
    {
        fontIncrease.onClick.RemoveAllListeners();
        fontDecrease.onClick.RemoveAllListeners();
    }
}
