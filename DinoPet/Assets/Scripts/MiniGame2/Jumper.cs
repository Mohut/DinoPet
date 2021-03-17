using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{

    public Rigidbody rb;

    public float jumpForce;
    public bool duck = false;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            
                if (Input.GetTouch(0).position.y > Screen.height / 2)
                {
                    Jump();
                    duck = false;
                }
                else
                {
                    Duck();
                    duck = true;
                }
                

            if (Input.GetTouch(0).phase == TouchPhase.Ended || !duck)
            {
                this.transform.localScale = new Vector3(1, 1, 1);
            }
            

        }

        
    }

    void Jump()
    {
        if (transform.position.y <= -0.5)
        {
            GetComponent<Rigidbody>().velocity = Vector2.up * jumpForce;
        }
    }

    void Duck()
    {
        if (transform.position.y <= -0.5)
        {
            this.transform.localScale = new Vector3(1, 0.5f, 1);
            duck = true;
        }
    }
}
