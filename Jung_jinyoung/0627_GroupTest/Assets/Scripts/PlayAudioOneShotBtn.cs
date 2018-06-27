using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioOneShotBtn : MonoBehaviour {

	public void OnCrickButton()
    {
        Debug.Log("oncrick");
        AudioTest.Audio.PlayAudio();
    }
}
