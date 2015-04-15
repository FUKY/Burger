using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FoodOrder : MonoBehaviour {

    public List<GameObject> foodList = new List<GameObject>();
    public GameObject[] food = new GameObject[12];
    public GameObject[] foodAdd = new GameObject[12];
    int indexOfList;
    public int indexOfMenu;
    public Transform foodTransform;
    FixItem fix;
	// Use this for initialization
	void Start ()
    {
        RandomFood();
        fix.Fix();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void CheckActive()
    {
        for (int i = 0; i < food.Length; i++)
        {
            if (food[i].activeSelf)
            {
                foodList.Add(foodAdd[i]);
            }
        }
    }

    void RandomItem(int i)
    {
        GameObject a;
        a = Instantiate(foodList[i],transform.position, Quaternion.identity) as GameObject;
        a.transform.parent = foodTransform;
    }

    [ContextMenu("Random")]
    void RandomFood()
    {
        CheckActive();
        indexOfMenu = Random.Range(3, 7);

        for (int i = 0; i < indexOfMenu; i++)
        {
            indexOfList = Random.Range(0, foodList.Count);
            RandomItem(indexOfList);
        }
        gameObject.GetComponent<FixItem>().Fix();
        Debug.Log("Random");
    }
}
