using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ClickAudio : MonoBehaviour
{
    public void Update()
    {
        bool clicked = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;
        if (clicked && EventSystem.current != null)
        {
            if(EventSystem.current.IsPointerOverGameObject())
            {
                AudioManager.OnAudioCallEvent?.Invoke("click");
            }
        }
    }
}