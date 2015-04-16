using UnityEngine;
using System.Collections;

public class PrefabScript : MonoBehaviour {

    public int index;
	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void CallOut(GameObject parentTransform)
    {
        GameObject trans;
        trans = Instantiate(gameObject, parentTransform.transform.position, Quaternion.identity) as GameObject;
        trans.transform.SetParent(parentTransform.transform);
    }
}
