using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour {
    [SerializeField]
    AudioClip audioClip;
    [SerializeField]
    AudioSource audioSource;
    public static AudioTest Audio;
    private void Start()
    {
        if (AudioTest.Audio == null)
            AudioTest.Audio = this;
        
        audioSource = gameObject.AddComponent<AudioSource>();
        //audioClip = GetComponent<AudioClip>();
    }

    public void PlayAudio()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
