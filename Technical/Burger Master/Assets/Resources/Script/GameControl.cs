using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class GameControl : MonoSingleton<GameControl> {

    public bool isDone = true;
    MenuType menuType;
    public GameObject food;
    public GameObject drink;
    int foodCount, drinkCount;

    CheckEnable checkEnable;
    //FoodOrder foodOrder;
    DrinkOrder drinkOrder;
    FixItem fixItem;
    public int numCheck;

    // Use this for initialization
	void Start () {
        checkEnable = gameObject.GetComponent<CheckEnable>();
        //foodOrder = gameObject.GetComponent<FoodOrder>();
        drinkOrder = gameObject.GetComponent<DrinkOrder>();
        fixItem = gameObject.GetComponent<FixItem>();
        menuType = CheckType();
        //float height = RectExtension.GetHeight((RectTransform)transform);
        //Debug.Log(System.String.Format("Height of order menu = {0}", height));
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if (isDone == true)
        //{
        //    FoodOrder.Instance.isRand = false;
        //    DrinkOrder.Instance.isRand = false;
        //    CheckMenuType(menuType = CheckType());
        //    FoodOrder.Instance.RandomFood();
        //    DrinkOrder.Instance.RandomDrink();
        //    isDone = false;
        //}
	}

    public bool CheckRight(int index)
    {
        if (numCheck >= 0)
        {
           // if (index == FoodOrder.Instance.listCheck[numCheck])
            {
                numCheck--;
                return true;
            }
            return false;
        }
        else
        {
            Debug.Log("Win");
            return false;
        }
    }

    [ContextMenu("Check")]
    void CheckMenuType(MenuType menuType)
    {
        switch (menuType)
        {
            case MenuType.food:
                {
                    food.SetActive(true);
                    drink.SetActive(false);
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
                }
                break;
            default:
                break;
        }
    }

    MenuType CheckType()
    {
        //if (FoodOrder.Instance.indexOfMenu == 0)
        //{
        //    return MenuType.drink;
        //}
        //else if (DrinkOrder.Instance.indexOfMenu == 0)
        //{
        //    return MenuType.food;
        //}
        //else
        //{
        //    return MenuType.foodDrink;
        //}
        return menuType;
    }
}

public enum MenuType
{
    food = 0,
    foodDrink = 1,
    drink = 2
}
