using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerScript : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource announcementAudioSource;
    private bool _max_volume = true;
    public void Update()
    {
        if (_max_volume == true)
        {
            musicAudioSource.volume += 0.1f * Time.deltaTime;
            if (musicAudioSource.volume == 1)
            {
                _max_volume = false;
            }
        }
    }
}
