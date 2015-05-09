using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoardItem : MonoBehaviour {

    public List<GameObject> listPrefabs;
    //public List<GameObject> listItem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowOrder(List<int> listOrder)
    {
        
    }

    //public void ActiveItem(List<int> listItemActive)
    //{
    //    foreach (GameObject item in listItem) 
    //    {
    //        item.GetComponent<CheckEnable>().SetEnable(false);
    //    }
    //    for (int i = 0; i < listItemActive.Count; i++ )
    //    {
    //        int index = listItemActive[i];
    //        listItem[index].GetComponent<CheckEnable>().SetEnable(true);
    //    }
    //}
}
