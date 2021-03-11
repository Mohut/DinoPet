using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class AktionSpace : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private Light light;
    [SerializeField] private SpriteRenderer nightSky;
    [SerializeField] private Animator animator;
    private Wink winkScript;

    private void Start()
    {
        winkScript = FindObjectOfType<Wink>();
    }
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
            animator.Play("SleepEnter");
            winkScript.asleep = 1;
            winkScript.Sleep();
            return;
        }

        if (light.intensity == 0.65f)
        { 
            light.intensity = 1;
            nightSky.enabled = false;
            animator.Play("SleepExit");
            winkScript.asleep = 0;
            winkScript.WakeUp();
        }
    }
}