using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    //Raycast
    public float range = 2;

    /* //Timer
     public int holdKey = 7;
     public float holdTimer;
     public TimerUI timerUI;
     public GameObject timerHUD;*/


    //Object
    public Item currentItem;
    bool itemPickedUp = false;

    //UI
    public GameObject InstructionUI;

    void Start()
    {
        //holdTimer = holdKey;
    }

    void Update()
    {
        //Timer
        //holdTimer -= Time.deltaTime;

        //Raycast
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward * range));
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * range));

        if (Physics.Raycast(ray, out hit, range))
        {
            Item item = hit.collider.GetComponent<Item>();
            currentItem = item;

            //Item
            if (hit.collider.tag == "item")
            {
                InstructionUI.SetActive(true);

                //Press E to pickup item
                if (Input.GetKeyDown("e"))
                {
                    ItemPickup();
                }
            }  
        }
        else
        {
            InstructionUI.SetActive(false);
        }

        //Press Q to release item
        if (Input.GetKeyDown("q"))
        {
            ItemRelease();
        }

        //Press Left mouse button to use item
        if (Input.GetMouseButtonDown(0))
        {
            ItemUse();
        }
    }

    //Methods

    void ItemPickup()
    {
        currentItem.Pickup();
        itemPickedUp = true;
    }

    void ItemRelease()
    {
        currentItem.Release();
        itemPickedUp = false;
    }

    void ItemUse()
    {
        if (itemPickedUp == true)
        {
            currentItem.Use();
        }
    }
}
