using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y <= 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
