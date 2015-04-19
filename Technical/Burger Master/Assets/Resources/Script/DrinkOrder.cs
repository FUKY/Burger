using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DrinkOrder : MonoBehaviour {

    public GameObject[] drink = new GameObject[8];
    GameObject prefabDrink;
    public SortedDictionary<int, GameObject> dictionaryDrink;
    public Transform drinkTransform;
    int indexOfMenu;
    int indexOfList;
    public GameControl gameControl;
    FixItem fixItem;
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
                Debug.Log(prefabDrink.name);
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
    void RandomDrink()
    {
        indexOfMenu = Random.Range(0, 2);
        fixItem.column = indexOfMenu;
        for (int i = 0; i < indexOfMenu; i++)
        {
            indexOfList = Random.Range(0, dictionaryDrink.Count);
            RandomItemDictionaryDrink(indexOfList);
        }
    }
}
