using UnityEngine;


public class TouchManager : MonoBehaviour
{
    private Vector3 touchPosition;
    [SerializeField] private Camera camera;
    public bool isDragged;
    private GameObject draggedObject;

    private void Start()
    {
        isDragged = false;
    }

    void Update()
    {
        //checks if someone is touching the screen
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            touchPosition = camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1));
            touchPosition.z = -10f;
            RaycastHit hit;
            
            //creates a raycast that is looking for colliders
            if (Physics.Raycast(touchPosition, Vector3.forward, out hit))
            {
                if (hit.collider.gameObject.tag.Equals("Food"))
                {
                    isDragged = true;
                    draggedObject = hit.collider.gameObject;
                }
            }
        }

        //sets the position from the draggedObject to the position of the finger
        if (isDragged)
        {
            var objectPosition = new Vector3(touchPosition.x, touchPosition.y, -9);
            draggedObject.transform.position = objectPosition;
        }

        if (Input.touchCount == 0)
        {
            isDragged = false;
        }
    }
}
