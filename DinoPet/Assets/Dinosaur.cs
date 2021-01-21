public class Dinosaur
{
    protected string name;
    protected int hunger;
    protected int thirst;
    protected int loneliness;
    protected int size;
    protected int level;
    protected bool ill;
    protected bool dead;
    protected bool active;
    protected bool plantEater;
    protected bool fleshEater;
    protected float desireTimer;

    public Dinosaur(string name, bool active, bool plantEater, bool fleshEater)
    {
        this.name = name;
        hunger = 100;
        thirst = 100;
        loneliness = 100;
        size = 1;
        level = 1;
        ill = false;
        dead = false;
        this.active = active;
        this.plantEater = plantEater;
        this.fleshEater = fleshEater;
        desireTimer = 86400;
    }
}
