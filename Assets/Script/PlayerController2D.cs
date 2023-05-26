using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

    public InventorySO inventory;
    public Rigidbody2D rb;

    private Animator animator;
    private float MoveSpeed = 5f;

    private bool isDashing;

    private Vector3 moveDirection;
    
    private float dashDuration = 0.2f;
    private float dashSpeed = 10f;
    private float dashCooldown = 2f;
    private float lastDashTime = -10f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 dir = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }
        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
        }





        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);


        if (!isDashing)
        {
            rb.velocity = MoveSpeed * dir;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time - lastDashTime > dashCooldown)
        {

            animator.SetBool("IsDashing", true);
            isDashing = true;
            moveDirection = dir;
            StartCoroutine(Dash(dashDuration));
            lastDashTime = Time.time;
        }
    }

    IEnumerator Dash(float duration)
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            rb.velocity = moveDirection * dashSpeed;
            yield return null;
        }
        isDashing = false;
    }
}
