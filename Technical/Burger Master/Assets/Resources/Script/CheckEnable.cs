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
    public GameObject transParent;
    FixItem fixItem;
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
    [ContextMenu("Check")]
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
        if (FoodOrder.Instance.dictionary.ContainsKey(index))
        {
            cucduocclick = FoodOrder.Instance.dictionary[index];
            trans = Instantiate(FoodOrder.Instance.dictionary[index], transform.position, Quaternion.identity) as GameObject;
            trans.transform.SetParent(transParent.transform);
        }
    }
}
