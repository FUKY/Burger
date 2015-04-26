using UnityEngine;
using System.Collections;

public class PositionCall : MonoBehaviour {

    FixItem fix;
    //FoodOrder foodOrder;
	// Use this for initialization
	void Start ()
    {
        fix = gameObject.GetComponent<FixItem>();
        // = gameObject.GetComponent<FoodOrder>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void Test()
    {
        fix.row = FoodOrder.Instance.indexOfMenu;
    }
}
