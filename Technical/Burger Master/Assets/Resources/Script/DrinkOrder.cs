using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DrinkOrder : MonoSingleton<DrinkOrder> {

    public GameObject[] drink = new GameObject[8];
    GameObject prefabDrink;
    public SortedDictionary<int, GameObject> dictionaryDrink;
    public Transform drinkTransform;
    public int indexOfMenu;
    int indexOfList;
    FixItem fixItem;
    public bool isRand = true;
	// Use this for initialization
	void Start ()
    {
        fixItem = gameObject.GetComponent<FixItem>();
        dictionaryDrink = new SortedDictionary<int, GameObject>();
        CheckActiveDrink();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isRand == false)
        {
            indexOfMenu = Random.Range(0, 2);
            isRand = true;
        }
	}

    void CheckActiveDrink()
    {
        CheckEnable checkEnable = null;
        for (int i = 0; i < drink.Length; i++)
        {
            checkEnable = drink[i].GetComponent<CheckEnable>();
            if (checkEnable.isEnable)
            {
                prefabDrink = Resources.Load<GameObject>("Prefab/Drink/b_addin" + checkEnable.index);
                dictionaryDrink.Add(checkEnable.index, prefabDrink);
            }
        }
    }

    void RandomItemDictionaryDrink(int i)
    {
        GameObject trans;
        trans = Instantiate(dictionaryDrink[dictionaryDrink.Keys.ElementAt(i)], transform.position, Quaternion.identity) as GameObject;
        trans.transform.SetParent(drinkTransform);
    }

    [ContextMenu("Random")]
    public void RandomDrink()
    {
        fixItem.row = indexOfMenu;
        for (int i = 0; i < indexOfMenu; i++)
        {
            indexOfList = Random.Range(0, dictionaryDrink.Count);
            RandomItemDictionaryDrink(indexOfList);
        }
        fixItem.Fix();
    }
}
