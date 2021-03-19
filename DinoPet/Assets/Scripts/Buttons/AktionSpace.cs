using System.Collections;
using UnityEngine;

public class AktionSpace : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private Light light;
    [SerializeField] private SpriteRenderer nightSky;
    [SerializeField] private Animator animator;
    private Wink winkScript;
    public bool animationActive;

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
        if (animationActive)
            return;

        animationActive = true;
        if (light.intensity == 1)
        {
            light.intensity = 0.65f;
            StartCoroutine(FadeIn());
            animator.Play("SleepEnter");
            winkScript.asleep = 1;
            winkScript.Sleep();
            return;
        }

        if (light.intensity == 0.65f)
        {
            light.intensity = 1;
            StartCoroutine(FadeOut());
            animator.Play("SleepExit");
            winkScript.asleep = 0;
            winkScript.WakeUp();
        }
    }

    IEnumerator FadeIn()
    {
        
        while(nightSky.color.a < 1)
        {
            nightSky.color = new Color(nightSky.color.r, nightSky.color.g, nightSky.color.b, nightSky.color.a + 0.02f);
            yield return new WaitForSeconds(0.02f);
        }

        animationActive = false;
        yield return null;
    }
    
    IEnumerator FadeOut()
    {
        while(nightSky.color.a > 0f)
        {
            nightSky.color = new Color(nightSky.color.r, nightSky.color.g, nightSky.color.b, nightSky.color.a - 0.02f);
            yield return new WaitForSeconds(0.02f);
        }

        animationActive = false;
        yield return null;
    }
}