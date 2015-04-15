using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrinkOrder : MonoBehaviour {

    public List<GameObject> drinkList = new List<GameObject>();
    public GameObject[] drink = new GameObject[8];
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void CheckActive()
    {
        for (int i = 0; i < drink.Length; i++)
        {
            if (drink[i].activeSelf)
            {
                drinkList.Add(drink[i]);
            }
        }
    }

    void RandomDrink()
    {

    }
}
