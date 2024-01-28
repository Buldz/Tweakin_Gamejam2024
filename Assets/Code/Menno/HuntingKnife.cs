using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntingKnife : Item
{
    public Balloon balloon;

    //Raycast
    public float range = 2;
    Ray ray;
    public bool isHit = false;

    public void Update()
    {
        isHit = false;

        ray = new Ray(transform.position, transform.TransformDirection(-Vector3.forward * range));
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.forward * range));

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.tag == "interactable")
            {
                isHit = true;
                balloon = hit.collider.GetComponent<Balloon>();
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
        if (isHit ==true)
        {
            balloon.Pop();
        }
    }
}
