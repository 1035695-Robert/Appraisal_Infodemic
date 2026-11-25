using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StatSlider : MonoBehaviour
{
    public static StatSlider instance;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    public static Action<string> OnUpdateStats;
    public Slider correctSlider;
    public Slider IncorrectSlider;

    [SerializeField] private int _correct;
    [SerializeField] private int _incorrect;
    [SerializeField] private int TotalRequests;

    private void OnEnable()
    {
        OnUpdateStats += SetStats;
    }

    public void SetStats(string requestState)
    {
        Debug.Log("set statistics");
        TotalRequests++;
        correctSlider.maxValue = TotalRequests;
        IncorrectSlider.maxValue = TotalRequests;

        switch (requestState)
        {
            case "Correct":
                _correct++;
                correctSlider.value = _correct;
                break;
            case "Incorrect":
                _incorrect++;
                IncorrectSlider.value = _incorrect;
                break;
        }
    }

    private void OnDisable()
    {
        OnUpdateStats -= SetStats;
    }
}