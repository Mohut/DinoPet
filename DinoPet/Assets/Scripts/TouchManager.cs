using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TouchManager : MonoBehaviour
{
    [SerializeField] private GameObject[] foodList;
    [SerializeField] private Animator animator;
    
    public bool isDragged;
    private GameObject draggedObject;
    private bool getPetted;
    private Vector3 currentPosition;


    void Awake () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        isDragged = false;
    }

    private void Start()
    {
        isDragged = false;
        getPetted = false;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
           //Pet();
           FoodInventory();

           if (isDragged)
           {
               var position = Camera.main.ScreenToWorldPoint(new Vector3(currentPosition.x, currentPosition.y, 1));
               draggedObject.transform.position = position;
           }

           
           

        }
        else if (isDragged)
        {
            Destroy(draggedObject);
            isDragged = false;
        }
    }

    public void FoodInventory()
    {
        currentPosition = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
        
        
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = currentPosition;

        List<RaycastResult> raycastResult = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResult);
        for (int i = 0; i < raycastResult.Count; i++)
        {
            if (raycastResult[i].gameObject.tag.Equals("FoodSlot") && !isDragged)
            {
                draggedObject = Instantiate(foodList[1], Camera.main.ScreenToWorldPoint(currentPosition), Quaternion.identity);
                isDragged = true;
            }

            if (!raycastResult[i].gameObject.tag.Equals("FoodSlot") && isDragged)
            {
                Destroy(draggedObject);
                isDragged = false;
            }
        }
    }

    public void Pet()
    {

        var position = Input.GetTouch(0).position;

        if (position.x <= 420 && position.x >= 250 && position.y >= 330 && position.y <= 750)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if (!getPetted)
                {
                    animator.Play("PetEnter");
                    getPetted = true;
                }
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
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
        

        if (Input.touchCount == 0)
        {
            if (getPetted)
                animator.Play("PetExit");

            getPetted = false;
        }
    }

}
