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


    public void Pickup()
    {
        this.transform.position =  itemLocation.transform.position;
        this.transform.rotation = itemLocation.transform.rotation; 
        this.gameObject.transform.parent = itemLocation.transform;
        rb.isKinematic = true;
    }

    public void Release()
    {
        this.gameObject.transform.parent = null;
        rb.isKinematic = false;
    }

    public abstract void Use();
}