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
            if (fileButtons.Exists(b => b.name == button.name)) return;
            button.onClick.AddListener(()=> OpenFile(button.name));
            button.name = button.name.Replace("Button", "").TrimEnd();
            Debug.Log(button.name);
            
            fileButtons.Add(button);
        }
    }

    private void OpenFile(string buttonName)
    {
      
        GameObject file = canvasWindowsUI.transform.Find(buttonName).gameObject;
        file.SetActive(true);

    }
}

