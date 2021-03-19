using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colliding : MonoBehaviour
{

    public GameObject scoremanager;
    public Score score;
    public Text healthtext;
    

    private void Start()
    {
        score = scoremanager.GetComponent<Score>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            Debug.Log("angestossen");
            Destroy(other.collider.gameObject);
            score.health--;
            Debug.Log(score.health);
            healthtext.text = score.health.ToString();
        }
    }
}
