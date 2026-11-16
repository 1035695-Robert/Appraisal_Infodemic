using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OpenArticle : MonoBehaviour
{
    [SerializeField] private GameObject articleGroup;
    [SerializeField] private GameObject canvasWindowsUI;
    [SerializeField] private List<Button> fileButtons = new List<Button>();


    private void OnEnable()
    {
        FindFiles();
    }

    private void FindFiles()
    {
        foreach (Button button in articleGroup.GetComponentsInChildren<Button>())
        {
            string cleanName = button.name.Replace("Button", "").TrimEnd();
            if (fileButtons.Exists(b => b.name == button.name)) continue;

            button.onClick.AddListener(() => OpenFile(cleanName));
            fileButtons.Add(button);
        }
    }

    private void OpenFile(string buttonName)
    {
        Transform target = canvasWindowsUI.transform.Find(buttonName);
        if (target != null)
        {
            target.gameObject.SetActive(true);
            target.SetAsLastSibling();
        }
        
    }
}