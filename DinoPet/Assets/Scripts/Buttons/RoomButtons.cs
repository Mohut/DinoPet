using System;
using System.Collections;
using UnityEngine;

public class RoomButtons : MonoBehaviour
{

    [SerializeField] private float duration;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject lampButton;
    [SerializeField] private GameObject inventory;
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
        if (winkScript.asleep == 1)
            return;
        
        if (transform.position.x == 0)
            return;
        
        StartCoroutine(LerpFromTo(transform.position, new Vector3(0, 3.5f, -1), duration));
        shopButton.SetActive(false);
        placeholder.SetActive(true);
        lampButton.SetActive(false);
        inventory.SetActive(false);
        WakeUp();
    }

    public void Shop()
    {
        if (winkScript.asleep == 1)
            return;
        
        if (transform.position.x == 32)
            return;

        StartCoroutine(LerpFromTo(transform.position, new Vector3(32, 3.5f, -1), duration));
        shopButton.SetActive(true);
        placeholder.SetActive(false);
        lampButton.SetActive(false);
        inventory.SetActive(false);
        WakeUp();
    }
    
    public void Wardrobe()
    {
        if (winkScript.asleep == 1)
            return;
        
        if (transform.position.x == 16)
            return;

        StartCoroutine(LerpFromTo(transform.position, new Vector3(16, 3.5f, -1), duration));
        shopButton.SetActive(false);
        placeholder.SetActive(true);
        lampButton.SetActive(false);
        inventory.SetActive(false);
        WakeUp();
    }
    
    public void Kitchen()
    {
        if (winkScript.asleep == 1)
            return;
        
        if (transform.position.x == -16)
            return;

        StartCoroutine(LerpFromTo(transform.position, new Vector3(-16, 3.5f, -1), duration));
        shopButton.SetActive(false);
        placeholder.SetActive(false);
        lampButton.SetActive(false);
        inventory.SetActive(true);
        WakeUp();
    }
    
    public void Bedroom()
    {
        if (winkScript.asleep == 1)
            return;
        
        if (transform.position.x == -32)
            return;

        StartCoroutine(LerpFromTo(transform.position, new Vector3(-32, 3.5f, -1), duration));
        shopButton.SetActive(false);
        placeholder.SetActive(false);
        lampButton.SetActive(true);
        inventory.SetActive(false);
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
            winkScript.asleep = 0;
            aktionSpace.Light();
            animator.Play("SleepExit");
            winkScript.WakeUp();
        }
    }
    
}
