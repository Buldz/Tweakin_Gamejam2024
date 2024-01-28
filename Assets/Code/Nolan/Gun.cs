using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Gun : Item
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private Canvas _canvas;

    [SerializeField] private RawImage _rawImage;
    private AudioSource _audioSource;
    public override void Use()
    {
        Used();
        Cursor.lockState = CursorLockMode.None;
        _audioSource = this.GetComponent<AudioSource>();
        Camera.main.cullingMask = 0;
        AudioSourcePlayer.GetComponent<AudioSource>().mute = true;
        _audioSource.PlayOneShot(_audioClips[0]);
        _audioSource.PlayOneShot(_audioClips[1]);
        _canvas = GetComponentInChildren<Canvas>();
        _rawImage = GetComponentInChildren<RawImage>();
        StartCoroutine(timer());
    }

    void Update()
    {
        if (hasBeenUsed)
        {
            AudioSourceMusic.GetComponent<AudioSource>().volume -= 0.3f * Time.deltaTime;
        }
        if (pickUp == true)
        {
            this.transform.localEulerAngles = new Vector3(-90, -80, 0);
        }
    }

    IEnumerator timer()
    {
        _canvas.enabled = true;
        yield return new WaitForSeconds(0.3f);
        _rawImage.enabled = false;
        _canvas.enabled = false;
        yield return new WaitForSeconds(6.5f);
        _canvas.enabled = true;

    }
}
