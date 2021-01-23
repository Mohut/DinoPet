
using UnityEngine;

public class DesiresButtons : MonoBehaviour
{
    [SerializeField] private GameObject fleshCube;
    private Buttons buttons;
    public GameObject activeObject;

    private void Start()
    {
        buttons = FindObjectOfType<Buttons>();
    }

    public void FleshCube()
    {
        if(activeObject==null)
        activeObject = Instantiate(fleshCube, new Vector3(0,-0.3f,-9), Quaternion.identity);
    }
}
