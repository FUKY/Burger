using UnityEngine;
using System.Collections;

public class CheckEnable : MonoBehaviour {

    public bool isEnable = false;
    public GameObject itemEnable;
    public GameObject itemDisable;
    // Use this for initialization
    void Start()
    {

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
            itemEnable.SetActive(true);
            itemDisable.SetActive(false);
        }
        else if (isEnable)
        {
            itemEnable.SetActive(false);
            itemDisable.SetActive(true);
        }
    }
}
