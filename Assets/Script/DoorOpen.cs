using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Animator Dooranim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Dooranim.SetTrigger("Open");
    }
}
