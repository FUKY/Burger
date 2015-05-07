using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    Dictionary<int, List<int>> order;
    
    public List<int> listFoodActive;
    public List<int> listDrinkActive;

    public List<GameObject> listFoodItem;
    public List<GameObject> listDrinkItem;

    public GameObject foodOrder;
    public GameObject drinkOrder;

    // Use this for initialization
	void Start () {
        order = RandomeOrder();
        ActiveItemFoodAndDrink();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    [ContextMenu("ActiveItem")]
    public void ActiveItemFoodAndDrink() 
    {
        ActiveItem(listFoodItem, listFoodActive);
        ActiveItem(listDrinkItem, listDrinkActive);
    }

    
    public void ActiveItem(List<GameObject> listItemObj, List<int> listItemActive) 
    {
        for (int i = 0; i < listItemObj.Count; i++)
        {
            GameObject item = listItemObj[i];
            item.GetComponent<CheckEnable>().SetEnable(false);
        }

        for (int i = 0; i < listItemActive.Count; i++)
        {
            int index = listItemActive[i];
            listItemObj[index].GetComponent<CheckEnable>().SetEnable(true);
        }
    }

    public void ShowOrder() 
    {
        
    }

    Dictionary<int, List<int>> RandomeOrder() 
    {
        Dictionary<int, List<int>> orderTemp = new Dictionary<int, List<int>>();

        int rand = Random.Range(0, 3);
        switch (rand) 
        {
            case (int)TypeOrder.NONE:
                //randome ra ca 2
                orderTemp.Add((int)TypeOrder.FOOD, RandomeListItem(TypeOrder.FOOD, listFoodActive));
                orderTemp.Add((int)TypeOrder.DRINK, RandomeListItem(TypeOrder.DRINK, listDrinkActive));
                break;
            case (int)TypeOrder.FOOD:
                orderTemp.Add((int)TypeOrder.FOOD, RandomeListItem(TypeOrder.FOOD, listFoodActive));
                break;
            case (int)TypeOrder.DRINK:
                orderTemp.Add((int)TypeOrder.DRINK, RandomeListItem(TypeOrder.DRINK, listDrinkActive));
                break;
        }
        return orderTemp;
    }

    List<int> RandomeListItem(TypeOrder type, List<int> listItemActive) 
    {
        List<int> listItem = new List<int>();
        int count = 0;
        if (type == TypeOrder.FOOD)
        {
            count = Random.Range(1, 5);
            listItem.Add((int)TypeFood.BASE);
        }
        else if (type == TypeOrder.DRINK)
        {
            count = 1;
        }

        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, listItemActive.Count);
            listItem.Add(listItemActive[index]);
        }

        if (type == TypeOrder.FOOD)
        {
            listItem.Add((int)TypeFood.CAPS);
        }

        return listItem;
    }
}
