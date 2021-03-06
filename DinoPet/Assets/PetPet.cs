using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetPet : MonoBehaviour
{
    [SerializeField] private Material open;
    [SerializeField] private Material closed;
    [SerializeField] private SkinnedMeshRenderer rightEyeMaterial;
    [SerializeField] private SkinnedMeshRenderer leftEyeMaterial;

    public float openTime;
    public float closeTime;
    
    void Start()
    {
        StartCoroutine(CloseEyes());
    }


    IEnumerator CloseEyes()
    {
        while (true)
        {
            yield return new WaitForSeconds(openTime);
            rightEyeMaterial.material = closed;
            leftEyeMaterial.material = closed;
            yield return new WaitForSeconds(closeTime);
            rightEyeMaterial.material = open;
            leftEyeMaterial.material = open;
        }
    }
}
