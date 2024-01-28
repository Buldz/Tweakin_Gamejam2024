using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HuntingKnife : Item
{
    //Raycast
    public float range = 2;
    RaycastHit hit; 

    public override void Use()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward * range));

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.tag == "interactable")
            {
                UnityEngine.Debug.Log("slash balloon");
            }
        }
    }
}
