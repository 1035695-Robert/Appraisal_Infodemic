using System;
using TMPro;
using UnityEngine;

public class ArticleSettings : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI textField;
   
   private void OnEnable()
   {
      EventManager.OnFontSizeUpdate += FontUpdateSize;
   }
   private void FontUpdateSize()
   {
      textField.fontSize = GameManager.instance.fontSize;
   }
   private void OnDisable()
   {
      EventManager.OnFontSizeUpdate -= FontUpdateSize;
   }
}
