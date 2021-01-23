
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject inventory;
    
    public void OpenMenu()
    {
        if (menuButtons.activeSelf)
        {
            menuButtons.SetActive(false);
        }
        else
        {
            menuButtons.SetActive(true);
        }
    }

    public void OpenInventory()
    {
        menu.SetActive(true);
        inventory.SetActive(true);
    }

    public void CloseMenu()
    {
        menuButtons.SetActive(false);
        menu.SetActive(false);
    }
}
