using UnityEngine;

public class UpperUIPosition : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(Screen.safeArea.width/2, Screen.safeArea.height -100, 0);
    }
}
