
using UnityEngine;

public class DesiresButtons : MonoBehaviour
{

    [SerializeField] private GameObject foodButtons;
    [SerializeField] private GameObject drinksButtons;
    [SerializeField] private GameObject medicineButtons;

    [SerializeField] private GameObject water;
    [SerializeField] private GameObject dinoJuice;

    [SerializeField] private GameObject medicine;

    [SerializeField] private GameObject fleshCube;
    [SerializeField] private GameObject mouse;
    [SerializeField] private GameObject chickenLeg;
    [SerializeField] private GameObject steak;
    public GameObject activeObject;


    public void Food()
    {
        foodButtons.SetActive(true);
        drinksButtons.SetActive(false);
        medicineButtons.SetActive(false);
    }

    public void Drinks()
    {
        foodButtons.SetActive(false);
        drinksButtons.SetActive(true);
        medicineButtons.SetActive(false);
    }

    public void Medicine()
    {
        foodButtons.SetActive(false);
        drinksButtons.SetActive(false);
        medicineButtons.SetActive(true);
    }

    public void FleshCube()
    {
        if(activeObject==null)
        activeObject = Instantiate(fleshCube, new Vector3(0,-0.3f,-9), Quaternion.identity);
    }

    public void Mouse()
    {
        if(activeObject==null)
        activeObject = Instantiate(mouse, new Vector3(0, -0.3f,-9), Quaternion.identity);
    }
    
    public void ChickenLeg()
    {
        if(activeObject==null)
        activeObject = Instantiate(chickenLeg, new Vector3(0, -0.3f,-9), Quaternion.identity);
    }
    
    public void Steak()
    {
        if(activeObject==null)
        activeObject = Instantiate(steak, new Vector3(0, -0.3f,-9), Quaternion.identity);
    }

    public void Water()
    {
        activeObject = Instantiate(water, new Vector3(0, -0.3f,-9), Quaternion.identity);
    }
    
    public void DinoJuice()
    {
        activeObject = Instantiate(dinoJuice, new Vector3(0, -0.3f,-9), Quaternion.identity);
    }

    public void MedicineSpawn()
    {
        activeObject = Instantiate(medicine, new Vector3(0, -0.3f,-9), Quaternion.identity);
    }
}
