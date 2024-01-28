using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinata : MonoBehaviour
{
    public AudioSource pinataPopAudio;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    public void Pop()
    {
        pinataPopAudio.Play();
        Destroy(this.gameObject);
    }
}
