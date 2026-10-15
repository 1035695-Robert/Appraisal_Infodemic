using System;
using TMPro;
using UnityEngine;

public class RequestField : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI  requestTitle;
   [SerializeField] private TextMeshProUGUI textField;

   private void OnEnable()
   {
      EventManager.OnRequestUpdate  += UpdateRequest;
   }

   private void UpdateRequest(string requestMessage,  string requestHeader, bool isRequest)
   {
      if (isRequest)
      {
         requestTitle.text = "Request: " +requestHeader;
      }
      else
      requestTitle.text = requestHeader;

      textField.text = requestMessage;
   }

   private void OnDisable()
   {
      EventManager.OnRequestUpdate -= UpdateRequest;
   }
}
