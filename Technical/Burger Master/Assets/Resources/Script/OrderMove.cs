using UnityEngine;
using System.Collections;

public class OrderMove : MonoBehaviour {

    public Transform newTransform;
    Rigidbody2D rigidbody2D;
	// Use this for initialization
	void Start ()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, newTransform.position, 10.0f);
    }
}
