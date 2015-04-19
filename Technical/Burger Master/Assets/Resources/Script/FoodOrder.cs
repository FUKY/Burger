using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class FoodOrder : MonoSingleton<FoodOrder> {

    public GameObject[] food = new GameObject[10];
    GameObject prefabFood;
    public SortedDictionary<int, GameObject> dictionaryFood;
    int indexOfList;
    public int indexOfMenu;
    public Transform foodTransform;
    FixItem fix;
    public GameObject above;
    public GameObject below;
    int prevIndex = -1;

	// Use this for initialization
	void Start ()
    {
        fix = gameObject.GetComponent<FixItem>();
        dictionaryFood = new SortedDictionary<int, GameObject>();
        CheckActiveFood();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //Cai ham checkActive nos goi truoc ham start cua thang nay luon
    void CheckActiveFood()
    {
        CheckEnable checkEnable = null; //Như a nói, index của item em đặt giống của prefab, đặt khác là sai :D :D
        for (int i = 0; i < food.Length; i++)
        {
            checkEnable = food[i].GetComponent<CheckEnable>();
            if (checkEnable.isEnable)
            {
                prefabFood = Resources.Load<GameObject>("Prefab/Food/b_in" + checkEnable.index);
                dictionaryFood.Add(checkEnable.index, prefabFood);
            }
        }
    }

    void RandomItemDictionaryFood(int i)
    {
        GameObject tranformParent;
        tranformParent = Instantiate(dictionaryFood[dictionaryFood.Keys.ElementAt(i)], transform.position, Quaternion.identity) as GameObject;
        tranformParent.transform.SetParent(foodTransform);
    }

    public void AboveInstantiate()
    {
        GameObject tranformParent;
        tranformParent = Instantiate(above, transform.position, Quaternion.identity) as GameObject;
        tranformParent.transform.SetParent(foodTransform);
    }

    public void BelowInstantiate()
    {
        GameObject tranformParent;
        tranformParent = Instantiate(below, transform.position, Quaternion.identity) as GameObject;
        tranformParent.transform.SetParent(foodTransform);
    }

    [ContextMenu("Random")]
    void RandomFood()
    {
        indexOfMenu = Random.Range(3, (dictionaryFood.Count > 5 ? 7: 5));
        fix.row = indexOfMenu;
        AboveInstantiate();
        for (int i = 0; i < indexOfMenu - 2; i++)
        {
            RandomMenu(indexOfList);
        }
        BelowInstantiate();
        fix.Fix();
    }
    
    void RandomMenu(int indexList)
    {
        indexList = Random.Range(1, dictionaryFood.Count - 1);
        if (prevIndex == -1)
        {
            prevIndex = indexList;
            RandomItemDictionaryFood(indexList);
        }
        else if (prevIndex != indexList)
        {
            prevIndex = indexList;
            RandomItemDictionaryFood(indexList);
        }
        else
        {
            RandomMenu(indexList);
            //prevIndex = indexOfList;
        }
    }
}