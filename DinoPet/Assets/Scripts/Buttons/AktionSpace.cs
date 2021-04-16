using System.Collections;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AktionSpace : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private Light light;
    [SerializeField] private SpriteRenderer nightSky;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject games;
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

    //turns the light on and off and lets the night sky appear and disappear
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
            StartCoroutine(SleepAnimations());
            winkScript.Sleep();
            return;
        }

        if (light.intensity == 0.65f)
        {
            winkScript.asleep = 0;
            light.intensity = 1;
            StartCoroutine(FadeOut());
            animator.Play("SleepExit");
            winkScript.WakeUp();
        }
    }

    //fades in the night sky
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
    
    //fades out the night sky
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

    IEnumerator SleepAnimations()
    {
        while (winkScript.asleep == 1)
        {
            yield return new WaitForSeconds(5);
            int randomNumber = Random.Range(0,3);
            switch (randomNumber)
            {
                case 0:
                    if(winkScript.asleep == 1)
                    animator.Play("sleepLoopHead");
                    break;
                case 1:
                    if(winkScript.asleep == 1)
                    animator.Play("sleepLoopTail");
                    break;
                case 2:
                    if(winkScript.asleep == 1)
                    animator.Play("sleepLoopMouth");
                    break;
            }
        }
        yield return null; 
    }

    public void Games()
    {
        games.SetActive(!games.activeSelf);
    }

    public void StartGames(int number)
    {
        SceneManager.LoadScene("Minigame" + number);
    }
}