using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    //Item
    public Transform itemLocation;
    public Rigidbody rb;
    [SerializeField] private Camera _playerCam;


    public void Pickup()
    {
        this.transform.position = itemLocation.transform.position;
        this.transform.rotation = itemLocation.transform.rotation;
        this.transform.localScale = this.transform.localScale / 10;
        this.gameObject.transform.parent = itemLocation.transform;
        rb.isKinematic = true;
    }

    public void Release()
    {
        this.gameObject.transform.parent = null;
        this.transform.rotation = Quaternion.identity;
        this.transform.localScale = this.transform.localScale * 10;
        rb.isKinematic = false;
    }

    public abstract void Use();

    void Update()
    {
        if (this.transform.localScale.x > 0.1)
            transform.LookAt(_playerCam.transform);
        else
        {
            this.transform.localEulerAngles = new Vector3(0,90,0);
        }
    }
}