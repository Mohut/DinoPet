
using System;
using TMPro;
using UnityEngine;

public class Utahraptor : Dinosaur
{
    [SerializeField] private TextMeshProUGUI hungerText;
    [SerializeField] private TextMeshProUGUI thirstText;
    [SerializeField] private TextMeshProUGUI lonelinessText;
    private void Start()
    {
        name = "Utahraptor";
        hunger = 100;
        thirst = 100;
        loneliness = 100;
        size = 1;
        level = 1;
        ill = false;
        dead = false;
        plantEater = false;
        fleshEater = true;
        desireTimer = 86400; 
    }

    private void Update()
    {
       // hungerText.text = hunger.ToString();
       // thirstText.text = thirst.ToString();
       // lonelinessText.text = loneliness.ToString();
    }
}
