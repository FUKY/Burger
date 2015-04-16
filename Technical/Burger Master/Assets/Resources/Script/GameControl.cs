using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public MenuType menuType;
    public GameObject food;
    public GameObject drink;
    public GridLayoutGroup grid;
	// Use this for initialization
	void Start () {
        grid = gameObject.GetComponent<GridLayoutGroup>();
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
                    grid.constraintCount = 1;
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
                    grid.constraintCount = 1;
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
