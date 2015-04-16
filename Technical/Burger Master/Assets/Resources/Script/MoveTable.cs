using UnityEngine;
using System.Collections;

public class MoveTable : MonoBehaviour {

    public bool isDone = false;
    public Transform newTransform;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isDone)
        {
            Move();
        }
	}

    [ContextMenu("Move")]
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, newTransform.position, 10.0f);
    }
}
