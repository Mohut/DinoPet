
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Utahraptor : MonoBehaviour
{
    [SerializeField] private Slider hungerBar;
    [SerializeField] private Slider thirstBar;
    [SerializeField] private Slider lonelinessBar;
    [SerializeField] private Slider illnessBar;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI coinsText;
    
    private string name;
    
    private int xp;
    public int coins;
    public int level;
    
    private bool dead;
    private float desireTimer;
    
    public float hunger;
    public float energy;
    public float affection;
    private float fun;
    private float illness;
    
    
    private void Start()
    {
        name = "Utahraptor";
        hunger = 10;
        fun = 10;
        energy = 10;
        illness = 10;
        level = 12;
        xp = 0;
        affection = 10;
        dead = false;
        desireTimer = 86400;
        coins = 2546;
        
        InvokeRepeating(nameof(DecreaseDesires), 1, 1);
    }

    private void Update()
    { 
       hungerBar.value = hunger/100;
       thirstBar.value = affection/100;
       lonelinessBar.value = fun/100;
       illnessBar.value = illness/100;
       levelText.text = level.ToString();
       
       
       //coinsText.text = coins.ToString();
    }
    
    public void Feed(Food food)
    {
        hunger += food.fillAmount;
        xp += food.xp;
        FindObjectOfType<Animator>().Play("eatingAnimation");
    }

    public void Medicine(Medicin medicin)
    {
        illness += medicin.fillAmount;
        xp += medicin.xp;
        FindObjectOfType<Animator>().Play("eatingAnimation");
    }
    
    public void DecreaseDesires()
    {
        hunger -= 100/desireTimer;
        fun -=  100/desireTimer;
        affection -= 100/desireTimer;
    }
}