using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public MenuType menuType;
    public GameObject food;
    public GameObject drink;
    public GridLayoutGroup gridOrder;

    public GridLayoutGroup gridFood;
    CheckEnable checkEnable;
    FoodOrder foodOrder;
    FixItem fixItem;
    public GameObject transParent;
    public GameObject above;
    public GameObject below;
    // Use this for initialization
	void Start () {
        gridOrder = gameObject.GetComponent<GridLayoutGroup>();
        checkEnable = gameObject.GetComponent<CheckEnable>(); //Sao e ko truyen tham chieu
        foodOrder = gameObject.GetComponent<FoodOrder>();
        fixItem = gameObject.GetComponent<FixItem>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    [ContextMenu("Check")]
    void CheckMenuType()
    {
        switch (menuType)
        {
            case MenuType.food:
                {
                    food.SetActive(true);
                    drink.SetActive(false);
                    gridOrder.constraintCount = 1;
                }
                break;
            case MenuType.foodDrink:
                {
                    food.SetActive(true);
                    drink.SetActive(true);
                }
                break;
            case MenuType.drink:
                {
                    food.SetActive(false);
                    drink.SetActive(true);
                    gridOrder.constraintCount = 1;
                }
                break;
            default:
                break;
        }
    }
}

public enum MenuType
{
    food = 0,
    foodDrink = 1,
    drink = 2
}
