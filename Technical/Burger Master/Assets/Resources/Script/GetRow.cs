using UnityEngine;
using System.Collections;

public class GetRow : MonoBehaviour {

    FixItem fix;
	// Use this for initialization
	void Start ()
    {
        fix = gameObject.GetComponent<FixItem>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    [ContextMenu("Test")]
    void GetRowOfMenu()
    {
        fix.row = FoodOrder.Instance.indexOfMenu;
    }
}
