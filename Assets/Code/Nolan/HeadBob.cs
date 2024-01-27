using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headbob : MonoBehaviour
{
    public Animator camAnim;

    void Update()
    {
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            camAnim.ResetTrigger("idle");
            camAnim.SetTrigger("walk");

        }
        else

        {
            camAnim.ResetTrigger("walk");
            camAnim.SetTrigger("idle");
        }
    }
}