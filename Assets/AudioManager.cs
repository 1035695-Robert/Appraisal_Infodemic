using System;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]AudioSource source;
    [SerializeField]private AudioClip[] clips;
    
    public static Action<string> OnAudioCallEvent;

    private void OnEnable()
    {
        OnAudioCallEvent += PlayAudio;
    }

    private void PlayAudio(string obj)
    {
        AudioClip targetClip = clips.FirstOrDefault(clip => clip.name == obj);
        if (targetClip != null)
        {
            source.PlayOneShot(targetClip);
        }
    }
}
