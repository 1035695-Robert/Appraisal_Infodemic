using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;


[Serializable]
public class NextList
{
    public GameObject[] EmailList;
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

    [SerializeField] private List<NextList> targetList  = new List<NextList>();
    public int RequestCompleted;

    public void ChecktoSendEmails(int  index, float waitTime)
    {
        StartCoroutine(CheckEmails(index, waitTime));
        
}

    private IEnumerator CheckEmails(int index, float waitTime)
    {
        if (targetList[index] == null) yield break;
        yield return new WaitForSeconds(waitTime);
        foreach(GameObject item in targetList[index].ArticleList)
        {
            var button =  item.GetComponent<Button>();
            button.interactable = true;
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
