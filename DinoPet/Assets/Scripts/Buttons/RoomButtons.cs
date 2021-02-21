using System.Collections;
using UnityEngine;

public class RoomButtons : MonoBehaviour
{

    [SerializeField] private float duration;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject lampButton;
    [SerializeField] private GameObject placeholder;
    public void PlayRoom()
    {
        if (transform.position.x == 0)
            return;
        
        StartCoroutine(LerpFromTo(transform.position, new Vector3(0, 3.5f, -1), duration));
        shopButton.SetActive(false);
        placeholder.SetActive(true);
        lampButton.SetActive(false);
    }

    public void Shop()
    {
        if (transform.position.x == 32)
            return;
        
        StartCoroutine(LerpFromTo(transform.position, new Vector3(32, 3.5f, -1), duration));
        shopButton.SetActive(true);
        placeholder.SetActive(false);
        lampButton.SetActive(false);
    }
    
    public void Wardrobe()
    {
        if (transform.position.x == 16)
            return;
        StartCoroutine(LerpFromTo(transform.position, new Vector3(16, 3.5f, -1), duration));
        shopButton.SetActive(false);
        placeholder.SetActive(true);
        lampButton.SetActive(false);
    }
    
    public void Kitchen()
    {
        if (transform.position.x == -16)
            return;
        
        StartCoroutine(LerpFromTo(transform.position, new Vector3(-16, 3.5f, -1), duration));
        shopButton.SetActive(false);
        placeholder.SetActive(true);
        lampButton.SetActive(false);
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
    
}
