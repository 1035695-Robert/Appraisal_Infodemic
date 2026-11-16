using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;


[Serializable]
public class NextList
{
    public string name;
    public GameObject[] EmailList;
    public GameObject[] RequestList;
    public GameObject[] ArticleList;
}

public class NextRequest : MonoBehaviour
{
    public static NextRequest instance;

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

    [SerializeField] private List<NextList> targetList = new List<NextList>();
    
    public int RequestCompleted;
    public int previousIndex;
    
    public void ChecktoSendEmails(int index, float waitTime)
    {
        if (targetList[index] == null) return;
        previousIndex = index;
        StartCoroutine(CheckEmails(index, waitTime));
    }

    public void CompletedRequests(int index, float waitTime)
    {
        if(index < 0 || index >= targetList.Count)
        {
            Debug.LogError("invalid index");
            return;
        }
        RequestCompleted++;
        Debug.Log(index + ":" + waitTime);
        Debug.Log(targetList[previousIndex].RequestList.Length + "requestCount");
        if (targetList[previousIndex].RequestList.Length <= RequestCompleted)
        {
            Debug.Log("All requests completed");
            RequestCompleted = 0;
            StartCoroutine(CheckEmails(index, waitTime));
            
        }
    }

    private IEnumerator CheckEmails(int index, float waitTime)
    {
        if (targetList[index] == null) yield break;

        yield return new WaitForSeconds(waitTime);

        foreach (GameObject item in targetList[index].ArticleList)
        {
            item.SetActive(true);
            var button = item.GetComponent<Button>();
            if(!button.interactable)
            {
                button.interactable = true;
            }
        }

        foreach (GameObject item in targetList[index].RequestList)
        {
            item.SetActive(true);
            yield return new WaitForSeconds(1);
        }

        foreach (GameObject item in targetList[index].EmailList)
        {
            item.SetActive(true);
            yield return new WaitForSeconds(1);
        }
    }
    
    public void IncreaseCountOfRequestsDone()
    {
        Debug.Log("IncreaseCountOfRequestsDone");
    }
}