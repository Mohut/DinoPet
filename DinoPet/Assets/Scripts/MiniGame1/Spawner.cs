using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject meteor;
    [SerializeField] private GameObject coin;
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1, 1);
    }

    public void Spawn()
    {
        var randomNumber = Random.Range(-0.2f, 0.2f);
        float objectToSpawn = Random.Range(0f, 1f);
        randomNumber = (float) Math.Round(randomNumber, 2);

        if (objectToSpawn > 0.5f)
        {
           Instantiate(meteor, new Vector3(randomNumber, transform.position.y, -9), Quaternion.identity); 
        }
        else
        {
            Instantiate(coin, new Vector3(randomNumber, transform.position.y, -9), Quaternion.identity); 
        }
        
    }
}
