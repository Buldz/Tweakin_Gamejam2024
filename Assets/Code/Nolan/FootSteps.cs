using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private Camera _mainCamera;

    private bool AllowSound;
    void Start()
    {
        AllowSound = false;
    }

    void Update()
    {
        AudioClip randomClip = _audioClips[Random.Range(0, _audioClips.Length)];
        if (_mainCamera.transform.localPosition.y < 0.465 && AllowSound)
        {
            _audioSource.PlayOneShot(randomClip);
            AllowSound = false;
        }
        if (_mainCamera.transform.localPosition.y > 0.49)
        {
            AllowSound = true;
        }
    }

}
