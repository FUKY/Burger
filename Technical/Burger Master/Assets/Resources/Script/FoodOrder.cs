using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class FoodOrder : MonoSingleton<FoodOrder> 
{
    public GameObject table;
    void Start()
    {
    }

    void Update()
    {
    }

    public void DestroyChild()
    {
        foreach (Transform child in gameObject.transform)
        {
            Destroy(child.gameObject);
        }
        PointController.Instance.AddScore();
    }
}
