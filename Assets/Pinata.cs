using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinata : MonoBehaviour
{
    public AudioSource pinataPopAudio;
    public ParticleSystem confetti;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void Pop()
    {
        pinataPopAudio.Play();
        confetti.Play();
        Destroy(this.gameObject);
    }
}
