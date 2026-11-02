using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class NextList
{
    public GameObject[] EmailList;
    public GameObject[] ArticleList;
}

public class NextRequest : MonoBehaviour
{
//     public static NextRequest instance;
//     private void Awake()
//     {
//         if (instance != null && instance != this)
//         {
//             Destroy(gameObject);
//             return;
//         }
//
//         instance = this;
//         DontDestroyOnLoad(gameObject);
//     }
//
//     [SerializeField] private List<NextList> targetList  = new List<NextList>();
//     public int RequestCompleted;
//
//     public void ChecktoSendEmails(int  index)
//     {
//         if (targetList[index] == null) return;
//         foreach (GameObject item in targetList[index].EmailList)
//         {
//             item.SetActive(true);
//         }
// }
//
//
//     public void IncreaseCountOfRequestsDone()
//     {
//         Debug.Log("IncreaseCountOfRequestsDone");
//     }
}
