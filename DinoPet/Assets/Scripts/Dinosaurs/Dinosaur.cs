
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    protected string name;
    protected float hunger;
    protected float thirst;
    protected float loneliness;
    protected int size;
    protected int level;
    protected bool ill;
    protected bool dead;
    protected bool plantEater;
    protected bool fleshEater;
    protected float desireTimer;
    protected int xp;
    protected float illness;
    protected int coins;

    public void Feed(Food food)
    {
        hunger += food.fillAmount;
        xp += food.xp;
        FindObjectOfType<Animator>().Play("eatingAnimation");
    }

    public void Drink(Drink drink)
    {
        thirst += drink.fillAmount;
        xp += drink.xp;
        FindObjectOfType<Animator>().Play("eatingAnimation");
    }

    public void Medicine(Medicin medicin)
    {
        illness += medicin.fillAmount;
        xp += medicin.xp;
        FindObjectOfType<Animator>().Play("eatingAnimation");
    }
}
