using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigame3_enemypatrol : MonoBehaviour
{

    public GameObject target;
    public int speed;

    public float timetochangespeed;
    private float starttimechange;
    private Vector3 stageDimensions;

    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        starttimechange = timetochangespeed;
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        targetPosition = generateRandomPosition();
        Debug.Log(stageDimensions.x + "|" +  stageDimensions.y);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (timetochangespeed <= 0)
        {
            speed = Random.Range(1, 3);
            timetochangespeed = starttimechange;
        }
        else
        {
            timetochangespeed -= Time.deltaTime;
        }
        */

        if (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 3);
            
        }
        else
        {
            targetPosition = generateRandomPosition();
        }
        
        
        //move to the position
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

    }

    Vector3 generateRandomPosition()
    {
        return new Vector3(Random.Range(0, stageDimensions.x), Random.Range(0, stageDimensions.y), 0);
    }

    
}
