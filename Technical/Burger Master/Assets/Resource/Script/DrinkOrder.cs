using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrinkOrder : MonoBehaviour {

    public List<GameObject> drinkList = new List<GameObject>();
    public GameObject[] drink = new GameObject[8];
    public GameObject[] drinkAdd = new GameObject[8];
    public Transform drinkTransform;
    int indexOfMenu;
    int indexOfList;
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
                drinkList.Add(drinkAdd[i]);
            }
        }
    }

    void RandomItem(int i)
    {
        GameObject a;
        a = Instantiate(drinkList[i], transform.position, Quaternion.identity) as GameObject;
        a.transform.parent = drinkTransform;
    }

    [ContextMenu("Random")]
    void RandomFood()
    {
        CheckActive();
        indexOfMenu = Random.Range(3, 7);

        for (int i = 0; i < indexOfMenu; i++)
        {
            indexOfList = Random.Range(0, drinkList.Count);
            RandomItem(indexOfList);
        }
    }
}
