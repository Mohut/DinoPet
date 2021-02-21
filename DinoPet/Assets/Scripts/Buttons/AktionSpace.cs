using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AktionSpace : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private Light light;
    [SerializeField] private SpriteRenderer nightSky;
    
    public void ShopButton()
    {
        shop.SetActive(!shop.activeSelf);
    }

    public void Light()
    {
        if (light.intensity == 1)
        {
            light.intensity = 0.65f;
            nightSky.enabled = true;
            return;
        }
            

        if (light.intensity == 0.65f)
        { 
            light.intensity = 1;
            nightSky.enabled = false;
        }
    }
}