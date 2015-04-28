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
    DrinkOrder drinkOrder;
    FixItem fixItem;
    public int numCheck;

    // Use this for initialization
	void Start () {
        checkEnable = gameObject.GetComponent<CheckEnable>();
        drinkOrder = gameObject.GetComponent<DrinkOrder>();
        fixItem = gameObject.GetComponent<FixItem>();
        numCheck = FoodOrder.Instance.listCheck.Count;
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
        if (numCheck > 0)
        {
            for (int i = 0; i < FoodOrder.Instance.listPrefab.Count; i++)
            {
                if (index == FoodOrder.Instance.listPrefab[i].GetComponent<PrefabScript>().index)
                {
                    numCheck--;
                    return true;
                }
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
}

public enum MenuType
{
    food = 0,
    foodDrink = 1,
    drink = 2
}
