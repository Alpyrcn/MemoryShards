using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

    public Rigidbody2D rb;

    private Animator animator;
    private float MoveSpeed = 6f;

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
            animator.SetInteger("Direction", 4);
        }


        if (!Input.anyKey)
        {
            animator.SetInteger("Direction", 0);
        }


        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);



        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }



        if (!isDashing)
        {
            rb.velocity = MoveSpeed * dir;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time - lastDashTime > dashCooldown)
        {
            
            
            isDashing = true;
            moveDirection = dir;
            StartCoroutine(Dash(dashDuration));
            lastDashTime = Time.time;
            AudioManager.Instance.PlaySFX("Dashing");
        }
    }

    IEnumerator Dash(float duration)
    {


        float time = 0;
        
        while (time < duration)
        {
            
            time += Time.deltaTime;
            animator.SetTrigger("Rolling");
            rb.velocity = moveDirection * dashSpeed;
            yield return null;
        }


        

        isDashing = false;
    }


    public void Attack()
    {
        animator.SetTrigger("IsAttacking");
        AudioManager.Instance.PlaySFX("SwordSwing");
    }


}
