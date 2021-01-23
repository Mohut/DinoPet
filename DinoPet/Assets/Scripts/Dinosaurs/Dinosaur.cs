using System;
using TMPro;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    protected string name;
    protected int hunger;
    protected int thirst;
    protected int loneliness;
    protected int size;
    protected int level;
    protected bool ill;
    protected bool dead;
    protected bool plantEater;
    protected bool fleshEater;
    protected float desireTimer;

    public void Feed(Food food)
    {
        hunger += food.fillAmount;
    }
}
