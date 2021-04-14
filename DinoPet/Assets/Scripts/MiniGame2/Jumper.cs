using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    public Rigidbody rb;
    public float jumpForce;
    public Animator animator;
    
    private bool duck = false;

    public Jumpbetter jumpbetter;
    private Vector3 originalSize;
    private BoxCollider[] boxColliders;


    private void Start()
    {
        jumpbetter = GetComponent<Jumpbetter>();
        originalSize = transform.localScale;
        animator = GetComponent<Animator>();
        boxColliders = GetComponents<BoxCollider>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            
                if (Input.GetTouch(0).position.y > Screen.height / 2)
                {
                    Jump();
                    duck = false;
                    //jumpbetter.Jumping();
                }
                else
                {
                    Duck();
                    duck = true;
                    
                }
                
            // if he isnt crouching anymore
            if (Input.GetTouch(0).phase == TouchPhase.Ended && duck)
            {
                duck = false;
                this.transform.localScale = originalSize;
                animator.SetBool("crouching", duck);
                boxColliders[0].enabled = true;
                boxColliders[1].enabled = false;

            }
            

        }

        
    }

    void Jump()
    {
        if (transform.position.y <= -0.5)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Duck()
    {
        if (transform.position.y <= -0.5)
        {
            duck = true;
            animator.SetBool("crouching", duck);
            boxColliders[0].enabled = false;
            boxColliders[1].enabled = true;

        }
    }
}
