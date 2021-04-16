using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpbetter : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public bool jumping = false;
    public bool falling = false;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //adjust fallvelocity when falling
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }


    public void Jumping()
    {
        
        Debug.Log("Jump");
        
    }
    

    public void Ducking()
    {
        Debug.Log("Ducked");
    }
}
