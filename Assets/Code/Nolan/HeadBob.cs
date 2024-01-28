using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    public Animator camAnim;

    private bool _state;
    void Update()
    {
        stateCheck();
        _state = false;
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            _state = true;
        }

    }

    public void stateCheck()
    {

        if (_state)
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
