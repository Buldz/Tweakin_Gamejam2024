using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoopeeCushion : Item
{
    public AudioSource cushionSound;
    public override void Use()
    {
        Used();
        cushionSound.Play();
    }
}
