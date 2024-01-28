using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingGlove : Item
{
    public Pinata pinata;
    public Guy guy;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;

    //Raycast
    public float range = 2;
    Ray ray;

    public bool pinataIsHit = false;
    public bool guyIsHit = false;

    public void Update()
    {
        pinataIsHit = false;
        guyIsHit = false;

        ray = new Ray(transform.position, transform.TransformDirection(-Vector3.forward * range));
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward * range));

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.tag == "interactable")
            {
                pinataIsHit = true;
                pinata = hit.collider.GetComponent<Pinata>();
            }

            if (hit.collider.tag == "guy")
            {
                guyIsHit = true;
                guy = hit.collider.GetComponent<Guy>();
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

    public override void Use()
    {
        Used();

        AudioClip randomClip = _audioClips[Random.Range(0, _audioClips.Length)];
        _audioSource.PlayOneShot(randomClip);

        if (pinataIsHit == true)
        {
            pinata.Pop();
        }

        if (guyIsHit == true)
        {
            guy.Hurt();
        }
    }
}
