using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameObject[] foodList;
    [SerializeField] private Animator animator;
    
    public bool isDragged;
    private GameObject draggedObject;
    private Vector3 currentPosition;
    private float eatingTimer;
    private bool eating;

    private bool getsPetted;
    private float notPetTimer;


    void Awake () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    private void Start()
    {
        isDragged = false;
        getsPetted = false;
        eating = false;
        notPetTimer = 1;
        eatingTimer = 2;
    }

    void Update()
    {
        if (eating)
        {
            eatingTimer -= Time.deltaTime;
        }

        if (eatingTimer <= 0)
        {
            eating = false;
        }
        
        if (Input.touchCount > 0)
        {
            FoodInventory();
            
            //checks if a finger is moving over the screen
            if (Input.GetTouch(0).phase == TouchPhase.Moved && !isDragged && !eating)
            {
                notPetTimer = 1;
                Pet(Input.GetTouch(0).position);
            }
            else
            {
                notPetTimer -= Time.deltaTime;
            }
            
           //lets the gameObject follow the finger of the player
           if (isDragged)
           {
               var position = new Vector3(currentPosition.x, currentPosition.y, 1);
               draggedObject.transform.position = Camera.main.ScreenToWorldPoint(position);
           }
        }
        //destroys the gameObject if the player does not touch the screen anymore
        else if (isDragged)
        {
            Destroy(draggedObject);
            isDragged = false;
        }
        
        //if the finger does not touch the screen after petting
        if (Input.touchCount == 0 && getsPetted)
        {
            notPetTimer -= Time.deltaTime;
        }
        
        //ends petting animation after one second not petting
        if (notPetTimer <= 0 && getsPetted)
        {
            getsPetted = false;
            animator.Play("petExit");
        }
    }

    
    //checks if the finger touches a food slot. if so it instantiates the corresponding food
    public void FoodInventory()
    {
        currentPosition = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);

        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = currentPosition;

        List<RaycastResult> raycastResult = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResult);
        for (int i = 0; i < raycastResult.Count; i++)
        {
            
            //checks if the finger is other a food slot
            if (raycastResult[i].gameObject.tag.Equals("FoodSlot") && !isDragged)
            {
                draggedObject = Instantiate(foodList[1], Camera.main.ScreenToWorldPoint(currentPosition), Quaternion.identity);
                isDragged = true;
            }
            
            //checks if the finger is over another UI element
            if (!raycastResult[i].gameObject.tag.Equals("FoodSlot") && isDragged && !raycastResult[i].gameObject.tag.Equals("Dino"))
            {
                Destroy(draggedObject);
                isDragged = false;
            }
            
            //checks if the finger is over the mouth of the dino
            if (raycastResult[i].gameObject.tag.Equals("Dino") && isDragged)
            {
                Destroy(draggedObject);
                isDragged = false;
                FindObjectOfType<Utahraptor>().Feed(foodList[1]);
                eatingTimer = 2;
                eating = true;
            }
        }
    }

    //checks if the player is petting the dino
    public void Pet(Vector3 touchPosition)
    {
        var position1 = Camera.main.ViewportToScreenPoint(new Vector2(0.3f, 0.3f));
        var position2 = Camera.main.ViewportToScreenPoint(new Vector2(0.6f, 0.7f));
        
        
        if (touchPosition.x > position1.x && touchPosition.x < position2.x &&
            touchPosition.y > position1.y && touchPosition.y < position2.y)
        {
            if (!getsPetted && !isDragged)
            {
                getsPetted = true;
                animator.Play("petEnter");
            }
        }
    }

}
