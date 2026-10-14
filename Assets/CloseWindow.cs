using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CloseWindow : MonoBehaviour
{
   public Button _closeButton;
   public GameObject targetWindow;
   
   private void Awake()
   {
      _closeButton = GetComponent<Button>();
   }

   private void OnEnable()
   {
      _closeButton.onClick.AddListener(OnButtonClick);
   }

   private void OnDisable()
   {
      _closeButton.onClick.RemoveListener(OnButtonClick);
   }

   private void OnButtonClick()
   {
      targetWindow.SetActive(false);
   }
}
