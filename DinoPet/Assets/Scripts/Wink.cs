using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wink : MonoBehaviour
{
    [SerializeField] private Material open;
    [SerializeField] private Material close;
    [SerializeField] private SkinnedMeshRenderer rightEyeMaterial;
    [SerializeField] private SkinnedMeshRenderer leftEyeMaterial;

    public float openTime;
    public float closeTime;
    public int asleep;
    
    void Start()
    {
        StartCoroutine(CloseEyes());
        asleep = 0;
    }


    IEnumerator CloseEyes()
    {
        while (asleep == 0)
        {
            yield return new WaitForSeconds(closeTime);
            rightEyeMaterial.material = open;
            leftEyeMaterial.material = open;
            yield return new WaitForSeconds(openTime);
            rightEyeMaterial.material = close;
            leftEyeMaterial.material = close;
        }
    }

    public void Sleep()
    {
        rightEyeMaterial.material = close;
        leftEyeMaterial.material = close;
    }

    public void WakeUp()
    {
        rightEyeMaterial.material = open;
        leftEyeMaterial.material = close;
        StartCoroutine(CloseEyes());
    }
    
}
