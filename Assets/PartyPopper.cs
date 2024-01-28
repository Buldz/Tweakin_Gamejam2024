using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyPopper : Item
{
    public AudioSource popperSound;
    public ParticleSystem popperParticleSystem;

    public override void Use()
    {
        Used();
        popperSound.Play();
        popperParticleSystem.Play();
    }
}
