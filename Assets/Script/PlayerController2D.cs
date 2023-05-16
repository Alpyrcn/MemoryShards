using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

    public Rigidbody2D rb;
    private Animator animator;

    private float MoveSpeed = 10f;

    private bool isdashing;
    
    private Vector3 movedirection;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = +1f;
          
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
            
        }

        movedirection = new Vector3(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isdashing = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = movedirection * MoveSpeed;

        if (isdashing)
        {
            float dashAmount = 4f;
            Vector3 dashPosition = transform.position + movedirection * dashAmount;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, movedirection, dashAmount);
            if (raycastHit2D.collider != null)
            {
                dashPosition = raycastHit2D.point;
            }
            rb.MovePosition(transform.position + movedirection * dashAmount);
            isdashing = false;
        }
    }
}
