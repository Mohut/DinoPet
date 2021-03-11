using System;
using System.Collections;
using UnityEngine;

public class RoomButtons : MonoBehaviour
{

    [SerializeField] private float duration;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject lampButton;
    [SerializeField] private GameObject placeholder;
    [SerializeField] private Light light;
    [SerializeField] private AktionSpace aktionSpace;
    [SerializeField] private Animator animator;
    private Wink winkScript;

    private void Start()
    {
        winkScript = FindObjectOfType<Wink>();
    }

    public void PlayRoom()
    {
        if (transform.position.x == 0)
            return;

        
        
        StartCoroutine(LerpFromTo(transform.position, new Vector3(0, 3.5f, -1), duration));
        shopButton.SetActive(false);
        placeholder.SetActive(true);
        lampButton.SetActive(false);
        WakeUp();
    }

    public void Shop()
    {
        if (transform.position.x == 32)
            return;

        StartCoroutine(LerpFromTo(transform.position, new Vector3(32, 3.5f, -1), duration));
        shopButton.SetActive(true);
        placeholder.SetActive(false);
        lampButton.SetActive(false);
        WakeUp();
    }
    
    public void Wardrobe()
    {
        if (transform.position.x == 16)
            return;

        StartCoroutine(LerpFromTo(transform.position, new Vector3(16, 3.5f, -1), duration));
        shopButton.SetActive(false);
        placeholder.SetActive(true);
        lampButton.SetActive(false);
        WakeUp();
    }
    
    public void Kitchen()
    {
        if (transform.position.x == -16)
            return;

        StartCoroutine(LerpFromTo(transform.position, new Vector3(-16, 3.5f, -1), duration));
        shopButton.SetActive(false);
        placeholder.SetActive(true);
        lampButton.SetActive(false);
        WakeUp();
    }
    
    public void Bedroom()
    {
        if (transform.position.x == -32)
            return;

        StartCoroutine(LerpFromTo(transform.position, new Vector3(-32, 3.5f, -1), duration));
        shopButton.SetActive(false);
        placeholder.SetActive(false);
        lampButton.SetActive(true);
    }

    IEnumerator LerpFromTo(Vector3 pos1, Vector3 pos2, float duration)
    {
        for (float t=0f; t<duration; t += Time.deltaTime) {
            transform.position = Vector3.Lerp(pos1, pos2, t / duration);
            yield return 0;
        }
        transform.position = pos2;
    }

    public void WakeUp()
    {
        if (light.intensity == 0.65f)
        {
            aktionSpace.Light();
            animator.Play("SleepExit");
            winkScript.asleep = 0;
            winkScript.WakeUp();
        }
    }
    
}
