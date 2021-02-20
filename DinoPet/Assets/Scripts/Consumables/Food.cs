using UnityEngine;

public class Food : MonoBehaviour
{
    public int fillAmount;
    public int xp;
    
    private TouchManager touchManager;

    private void Start()
    {
        touchManager = FindObjectOfType<TouchManager>();
    }

    //Destroys gameObject when it collides with the collider from the dinosaur and fills hunger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Dino"))
        {
            touchManager.isDragged = false;
            other.gameObject.GetComponentInParent<Utahraptor>().Feed(this);
            Destroy(gameObject);
        }
    }

}