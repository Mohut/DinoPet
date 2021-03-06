using UnityEngine;


public class TouchManager : MonoBehaviour
{
    private Vector3 touchPosition;
    [SerializeField] private Camera camera;
    public bool isDragged;
    private GameObject draggedObject;
    [SerializeField] private Animator animator;
    private bool getPetted;
    

    private void Start()
    {
        isDragged = false;
        getPetted = false;
    }

    void Update()
    {
        //checks if someone is touching the screen
        if (Input.touchCount > 0)
        {
        
        /*
            var touch = Input.GetTouch(0);
            touchPosition = camera.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1));
            touchPosition.z = -10f;
            RaycastHit hit;

            //creates a raycast that is looking for colliders
            if (Physics.Raycast(touchPosition, Vector3.forward, out hit))
            {
                if (hit.collider)
                {
                   if (hit.collider.gameObject.tag.Equals("Draggable"))
                   {
                       isDragged = true;
                       draggedObject = hit.collider.gameObject;
                   }
                   
                   if (hit.collider.gameObject.tag.Equals("Pet")) 
                   {
                       if(!getPetted)
                           animator.Play("PetEnter");
                       
                       getPetted = true; 
                   }
                }
            }
            
            */
        
            var position = Input.GetTouch(0).position;
            Debug.Log(position);
            

            if (position.x <= 420 && position.x >= 250 && position.y >= 330 && position.y <= 750)
            {
                
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    if (!getPetted)
                    {
                        animator.Play("PetEnter");
                        getPetted = true;
                    }
                    Debug.Log(position);
                }else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    
                }
            }
            else
            {
                if (getPetted)
                {
                    animator.Play("PetExit");
                    getPetted = false;
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
            
            if(getPetted)
                animator.Play("PetExit");
            
            getPetted = false;
        }
    }
}
