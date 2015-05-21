using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class FoodOrder : MonoSingleton<FoodOrder> 
{
    void Update()
    {
        //FixItemFood();
    }
    void FixItemFood()
    {
        if (gameObject.GetComponent<Transform>().childCount > 0 && GameController.Instance.isDone)
        {
            Debug.Log(gameObject.GetComponent<Transform>().childCount);
            gameObject.GetComponent<FixItem>().Fix();
        }
    }
}
