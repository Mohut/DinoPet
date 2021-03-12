using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_game_2 : MonoBehaviour
{

    public GameObject[] obstacles;

    private float timeBtwSpawn;

    public float startTimeBtwSpawn;

    public float decreaseTime;

    public float minTime = 0.65f;
    


    // Update is called once per frame
    void Update()
    {

        if (timeBtwSpawn <= 0)
        {
            int rand = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[rand], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;

        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }

    }
}
