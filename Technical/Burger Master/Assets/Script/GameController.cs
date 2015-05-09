using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameController : MonoBehaviour {

    Dictionary<int, List<int>> order;
    
    public List<int> listFoodActive;
    public List<int> listDrinkActive;

    public List<GameObject> listFoodItem;
    public List<GameObject> listDrinkItem;
    public List<GameObject> listFoodPrefab;
    public List<GameObject> listDrinkPrefab;

    public GameObject foodOrder;
    public GameObject drinkOrder;

    public bool isDone = false;

    // Use this for initialization
	void Start () {
        ActiveItemFoodAndDrink();
        order = RandomeOrder();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDone == true)
        {
            ShowOrder();
            isDone = false;
        }
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
        ShowFood();
    }

    //Random kiểu menu
    Dictionary<int, List<int>> RandomeOrder() 
    {
        Dictionary<int, List<int>> orderTemp = new Dictionary<int, List<int>>();

        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case (int)TypeOrder.NONE:
                foodOrder.SetActive(true);
                drinkOrder.SetActive(true);
                //randome ra ca 2
                orderTemp.Add((int)TypeOrder.FOOD, RandomeListItem(TypeOrder.FOOD, listFoodActive));
                orderTemp.Add((int)TypeOrder.DRINK, RandomeListItem(TypeOrder.DRINK, listDrinkActive));
                break;
            case (int)TypeOrder.FOOD:
                foodOrder.SetActive(false);
                drinkOrder.SetActive(true);
                orderTemp.Add((int)TypeOrder.FOOD, RandomeListItem(TypeOrder.FOOD, listFoodActive));
                break;
            case (int)TypeOrder.DRINK:
                drinkOrder.SetActive(false);
                foodOrder.SetActive(true);
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
            count = Random.Range(1, 6);
            listItem.Add((int)TypeFood.BASE);
        }
        else if (type == TypeOrder.DRINK)
        {
            count = Random.Range(1, 3);
        }
        if (listItemActive.Count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                int index = Random.Range(0, listItemActive.Count);
                listItem.Add(listItemActive[index]);
            }
        }

        if (type == TypeOrder.FOOD)
        {
            listItem.Add((int)TypeFood.CAPS);
        }
        return listItem;
    }

    void ShowFood()
    {
        for (int i = 0; i < listFoodActive.Count; i++)
        {
            GameObject trans = Instantiate(listFoodPrefab[listFoodActive[i]], transform.position, Quaternion.identity) as GameObject;
            trans.transform.SetParent(foodOrder.transform);
        }
    }

    void ShowDrink()
    {

    }
}