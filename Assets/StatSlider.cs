using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class StatSlider : MonoBehaviour
{

   public static Action<string> OnUpdateStats;
   public Slider correctSlider;
   public Slider IncorrectSlider;

   private int _correct;
   private int _incorrect;
   private int TotalRequests;

   private void OnEnable()
   {
      OnUpdateStats += SetStats;
   }

   public void SetStats(string requestState)
   {
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
