using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class GameController : MonoSingleton<GameController> {

    Dictionary<int, List<int>> order;
    
    public List<int> listFoodActive;
    public List<int> listDrinkActive;

    public List<GameObject> listFoodItem;
    public List<GameObject> listDrinkItem;
    public List<GameObject> listFoodPrefab;
    public List<GameObject> listDrinkPrefab;

    public List<Button> listButtonFood; //Chứa các button để có thể active hoặc disactive
    public List<Button> listButtonDrink;
    
    public GameObject foodOrder;
    public GameObject drinkOrder;
    public List<int> listFoodCheck = new List<int>();

    public bool isDone = true;

    // Use this for initialization
	void Start () {
        ActiveItemFoodAndDrink();
        //order = RandomeOrder();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDone == true)
        {
            order = RandomeOrder();
            ShowOrder();
            isDone = false;
            Invoke("Fix", 0.01f); //Delay số giây
        }
	}

    void Fix()
    {
        foodOrder.GetComponent<FixItem>().Fix();
    }

    [ContextMenu("ActiveItem")]
    public void ActiveItemFoodAndDrink() 
    {
        ActiveItem(listFoodItem, listFoodActive, listButtonFood);
        ActiveItem(listDrinkItem, listDrinkActive, listButtonDrink);
    }

    
    public void ActiveItem(List<GameObject> listItemObj, List<int> listItemActive, List<Button> listButton) 
    {
        for (int i = 0; i < listItemObj.Count; i++)
        {
            GameObject item = listItemObj[i];
            item.GetComponent<CheckEnable>().SetEnable(false);
            listButton[i].enabled = false;
        }

        for (int i = 0; i < listItemActive.Count; i++)
        {
            int index = listItemActive[i];
            listItemObj[index].GetComponent<CheckEnable>().SetEnable(true);
            listButton[index].enabled = true;
        }
    }

    public void ShowOrder() 
    {
        ShowFood();
        ShowDrink();
    }

    //Random kiểu menu
    Dictionary<int, List<int>> RandomeOrder() 
    {
        Dictionary<int, List<int>> orderTemp = new Dictionary<int, List<int>>();
        int rand;
        if (listDrinkActive.Count <= 0)
        {
            rand = 1;
        }
        else
        {
            rand = Random.Range(0, 3);
        }
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
                foodOrder.SetActive(true);
                drinkOrder.SetActive(false);
                orderTemp.Add((int)TypeOrder.FOOD, RandomeListItem(TypeOrder.FOOD, listFoodActive));
                break;
            case (int)TypeOrder.DRINK:
                drinkOrder.SetActive(true);
                foodOrder.SetActive(false);
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
            count = 1;
        }
        if (listItemActive.Count > 0)
        {
            int prev = 0;
            int index = 0;
            for (int i = 0; i < count; i++)
            {
                do
                {
                    index = Random.Range(1, listItemActive.Count - 1);
                } while (prev == index);
                prev = index;
                Debug.Log(index);
                listItem.Add(listItemActive[index]);
            }
        }

        if (type == TypeOrder.FOOD)
        {
            listItem.Add((int)TypeFood.CAPS);
        }
        return listItem;
    }

    List<int> ShowFood()
    {
        if (order.ContainsKey((int)TypeOrder.FOOD))
        {
            listFoodCheck = null;
            listFoodCheck = order[(int)TypeOrder.FOOD];
            for (int i = listFoodCheck.Count - 1; i >= 0 ; i--)
            {
                GameObject trans = Instantiate(listFoodPrefab[listFoodCheck[i]], transform.position, Quaternion.identity) as GameObject;
                trans.transform.SetParent(foodOrder.transform);
                trans.transform.localScale = Vector3.one;
            }
        }
        return listFoodCheck;
    }

    void ShowDrink()
    {
        List<int> listDrinkTemp = new List<int>();
        if (order.ContainsKey((int)TypeOrder.DRINK))
        {
            listDrinkTemp = order[(int)TypeOrder.DRINK];
            
            for (int i = 0; i < listDrinkTemp.Count; i++)
            {
                GameObject trans = Instantiate(listDrinkPrefab[listDrinkTemp[i]], transform.position, Quaternion.identity) as GameObject;
                trans.transform.SetParent(drinkOrder.transform);
                trans.transform.localScale = Vector3.one;
            }
        }
    }

    public int numCheck = 0;
    public bool Check(int foodType)
    {
        if (numCheck < listFoodCheck.Count)
        {
            if (foodType == listFoodCheck[numCheck])
            {
                numCheck++;
                if (numCheck == listFoodCheck.Count)
                {
                    MoveTable.Instance.isMove = true;
                    DestroyFoodOrder();
                    numCheck = 0;
                }
                return true;
            }
            else
            {
                numCheck = 0;
            }
        }
        return false;
    }

    void DestroyFoodOrder()
    {
        foreach (Transform child in foodOrder.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ResetGameMain()
    {
        CheckEnable checkEnable = (CheckEnable)GameObject.Find("food_item_11").GetComponent(typeof(CheckEnable));
        checkEnable.DestroyFood();
        DestroyFoodOrder();
        TimeRemain.Instance.ResetTime();
        PointController.Instance.ResetScore();
        numCheck = 0;
        isDone = true;
    }

    public void AddItem()
    {
        if (LevelController.Instance.GetLevel() > 1)
        {
            int index = RandomItem();
            listFoodActive.Insert(listFoodActive.Count - 1, index);
            ActiveItemFoodAndDrink();
        }
    }

    int RandomItem()
    {
        int index;
        foreach (int item in listFoodActive)
        {
            index = Random.Range(0, listFoodItem.Count);
            if (!listFoodActive.Contains(index))
            {
                return index;
            }
        }
        return -1;
    }
}