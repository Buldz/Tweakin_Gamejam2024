using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : MonoBehaviour
{
    //Object
    public Transform itemLocation;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void Use()
    {
        Debug.Log("used");
    }
}
