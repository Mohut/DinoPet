using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame1Controll : MonoBehaviour
{

    private Vector3 touchPosition;
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject player;
    private bool isDragged;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            touchPosition = camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1));
            
            
            touchPosition.z = -10f;
            RaycastHit hit;
            
            //creates a raycast that is looking for colliders
            if (Physics.Raycast(touchPosition, Vector3.forward, out hit))
            {
                isDragged = true;
            }
        }

        if (Input.touchCount == 0)
        {
            isDragged = false;
        }

        if (isDragged)
        {
            player.transform.position = new Vector3(touchPosition.x, player.transform.position.y, player.transform.position.z);
        }
    }
}
