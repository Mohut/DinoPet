using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int score;

    public int health;

    public float timetogetscore;

    public float startscoretime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startscoretime = timetogetscore;

    }

    // Update is called once per frame
    void Update()
    {

        if (timetogetscore <= 0)
        {
            score++;
            Debug.Log(score);
            timetogetscore = startscoretime;
        }
        else
        {
            timetogetscore -= Time.deltaTime;
        }
        
        
        if (health <= 0)
        {
            Debug.Log("Game Over");
        }
        
    }
}
