using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt()
    {
        UnityEngine.Debug.Log("oof");
        AudioClip randomClip = _audioClips[Random.Range(0, _audioClips.Length)];
        _audioSource.PlayOneShot(randomClip);
    }
}
