using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partyhat : Item
{
    public AudioSource partyHatSound;

    public override void Use()
    {
        Used();
        partyHatSound.Play();
    }
}
