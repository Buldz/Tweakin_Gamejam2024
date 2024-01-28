using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public AudioSource balloonPopAudio;
    public ParticleSystem confetti;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void Pop()
    {
        balloonPopAudio.Play();
        confetti.Play();
        Destroy(this.gameObject);
    }
}
