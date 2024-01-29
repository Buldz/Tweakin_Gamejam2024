using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun : Item
{
    [SerializeField] private AudioClip[] _audioClips;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private RawImage _rawImage;
    private GameObject AudioSourceMusic;
    private GameObject AudioSourcePlayer;
    private AudioSource _audioSource;
    private bool BeenHit;
    Ray ray;
    private float range = 300;
    public override void Use()
    {
        if (!hasBeenUsed && BeenHit)
        {
            Used();
            AudioSourceMusic = GameObject.FindGameObjectWithTag("Music");
            AudioSourcePlayer = GameObject.FindGameObjectWithTag("PlayerSounds");
            Cursor.lockState = CursorLockMode.None;
            _audioSource = this.GetComponent<AudioSource>();
            Camera.main.cullingMask = 0;
            AudioSourcePlayer.GetComponent<AudioSource>().mute = true;
            _audioSource.PlayOneShot(_audioClips[0]);
            _audioSource.PlayOneShot(_audioClips[1]);
            _canvas = GetComponentInChildren<Canvas>();
            _rawImage = GetComponentInChildren<RawImage>();
            StartCoroutine(timer());
            hasBeenUsed = true;
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

    public void Check()
    {
        BeenHit = false;
        ray = new Ray(transform.position, transform.TransformDirection(Vector3.down * range));
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down * range));
        if (Physics.Raycast(ray, out hit, range))
        {

            if (hit.collider.tag == "victim")
            {
                BeenHit = true;
            }
        }
        if (pickUp == false)
        {
            transform.LookAt(Camera.main.transform);
        }
        else
        {
            this.transform.localEulerAngles = new Vector3(0, 90, 0);
        }
    }
    void Update()
    {
        Check();
        if (hasBeenUsed)
        {
            AudioSourceMusic.GetComponent<AudioSource>().volume -= 0.3f * Time.deltaTime;
        }
        if (pickUp == true && !hasBeenUsed)
        {
            this.transform.localEulerAngles = new Vector3(-90, -80, 0);
            
        }
        else
        {
        transform.rotation = Quaternion.identity;
        }
    }
}
