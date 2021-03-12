using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jumper : MonoBehaviour
{

    public Rigidbody rb;

    public float jumpForce;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (transform.position.y <= -0.5)
            {
                GetComponent<Rigidbody>().velocity = Vector2.up * jumpForce;
            }
            
        }
    }
}
