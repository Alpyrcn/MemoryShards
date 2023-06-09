using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    private Animator Dooranim;


    private void Start()
    {
        Dooranim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Dooranim.SetBool("Open", true);
            AudioManager.Instance.PlaySFX("DoorSlam");
        }
        
    }
}
