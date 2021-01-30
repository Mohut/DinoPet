using System;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    private int currentCoins;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private Image endgameScreen;
    private void Start()
    {
        Time.timeScale = 1;
        currentCoins = 0;
        coinsText.text = currentCoins.ToString();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Coin"))
        {
            currentCoins++;
            coinsText.text = currentCoins.ToString();
            Destroy(other.gameObject);
        }
        else
        {
            Time.timeScale = 0;
            endgameScreen.gameObject.SetActive(true);
        }
    }
}
