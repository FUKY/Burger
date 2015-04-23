using UnityEngine;
using System.Collections;

public class MoveTable : MonoBehaviour {

    public bool isDone;
    public Transform newTransformLeft;
    public Transform newTransformRight;
	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Thành công");
        }
	}
}
