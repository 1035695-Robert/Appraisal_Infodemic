using System;
using TMPro;
using UnityEngine;

public class ArticleSettings : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI textField;
   
   [TextArea(10, 20)] [SerializeField] private string fileWithoutHints;

   [TextArea(10, 20)] [SerializeField] private string fileWithHints;
   private void OnEnable()
   {
      EventManager.OnFontSizeUpdate += FontUpdateSize;
      EventManager.OnToggleHints += Hints;
      Hints();
   }

   private void Hints()
   {
      if(GameManager.instance.isToggleHints && !string.IsNullOrEmpty(fileWithHints))
         textField.text = fileWithHints;
      else
         textField.text = fileWithoutHints;
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
