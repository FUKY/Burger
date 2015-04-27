using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class CheckEnable : MonoBehaviour {

    public bool isEnable = false;
    public int index;
    public GameObject itemEnable;
    public GameObject itemDisable;
    public GameObject transParentFood;
    public GameObject transParentDrink;
    FixItem fixItem;
    int numCheck;
    // Use this for initialization
    void Start()
    {
        fixItem = gameObject.GetComponent<FixItem>();
        Check();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Check()
    {
        if (!isEnable)
        {
            itemEnable.SetActive(false);
            itemDisable.SetActive(true);
        }
        else if (isEnable)
        {
            itemEnable.SetActive(true);
            itemDisable.SetActive(false);
        }
    }

    public void FoodClick()
    {
        GameObject cucduocclick;
        GameObject trans;
        if (index == FoodOrder.Instance.listCheck[numCheck].GetComponent<PrefabScript>().index) //Kiểm tra index của cục được click với index của item bên trong listCheck
        {
            if (GameControl.Instance.CheckRight(index))
            {
                Debug.Log(FoodOrder.Instance.listPrefab[numCheck].GetComponent<PrefabScript>().index);
                cucduocclick = FoodOrder.Instance.listPrefab[numCheck];
                trans = Instantiate(FoodOrder.Instance.listPrefab[numCheck], transform.position, Quaternion.identity) as GameObject;
                trans.transform.SetParent(transParentFood.transform);
                numCheck++;
            }
        }
    }

    public void DrinkClick()
    {
        GameObject cucduocclick;
        GameObject trans;
        if (DrinkOrder.Instance.dictionaryDrink.ContainsKey(index))
        {
            if (true)
            {
                cucduocclick = DrinkOrder.Instance.dictionaryDrink[index];
                trans = Instantiate(DrinkOrder.Instance.dictionaryDrink[index], transform.position, Quaternion.identity) as GameObject;
                trans.transform.SetParent(transParentDrink.transform);
            }
        }
    }
}
