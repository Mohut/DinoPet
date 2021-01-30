
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject inventory;
    private bool openMenu;

    private void Start()
    {
        openMenu = false;
    }

    public void OpenMenu()
    {
        if (openMenu)
        {
            menuButtons.SetActive(false);
            openMenu = false;
        }
        else
        {
            menuButtons.SetActive(true);
            openMenu = true;
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
        openMenu = false;
    }

    public void Test()
    {
       menuButtons.SetActive(false); 
    }

    public void MainGame()
    {
        SceneManager.LoadScene("InGame");
    }

    public void Minigame1()
    {
        SceneManager.LoadScene("Minigame1");
    }
}
