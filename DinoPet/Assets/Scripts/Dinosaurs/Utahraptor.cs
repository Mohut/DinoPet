
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Utahraptor : Dinosaur
{
    [SerializeField] private Slider hungerBar;
    [SerializeField] private Slider thirstBar;
    [SerializeField] private Slider lonelinessBar;
    [SerializeField] private Slider illnessBar;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI coinsText;
    
    private void Start()
    {
        name = "Utahraptor";
        hunger = 10;
        thirst = 100;
        loneliness = 100;
        size = 1;
        level = 12;
        xp = 0;
        ill = false;
        dead = false;
        plantEater = false;
        fleshEater = true;
        desireTimer = 86400;
        illness = 100;
        coins = 2546;
    }

    private void Update()
    { 
       hungerBar.value = hunger/100;
       thirstBar.value = thirst/100;
       lonelinessBar.value = loneliness/100;
       illnessBar.value = illness/100;
       levelText.text = level.ToString();
       coinsText.text = coins.ToString();
    }
}
