using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Screen.safeArea.width / 2, Screen.safeArea.height - 200, 0);
    }
    
}
