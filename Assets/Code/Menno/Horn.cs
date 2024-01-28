using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horn : Item
{
    public AudioSource hornSound; 
    public override void Use()
    {
        Used();
        hornSound.Play();
    }
}
