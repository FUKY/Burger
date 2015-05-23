using UnityEngine;
using System.Collections;

public class MoveTable : MonoSingleton<MoveTable> {

    public GameObject tableContainer;
    public bool isMove = false;
    Vector3 posStart;
	// Use this for initialization
	void Start () {
        posStart = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Move());
	}

    void StartMove()
    {
        iTween.MoveTo(gameObject, tableContainer.transform.position, 1.0f);
    }

    void MoveBack()
    {
        iTween.MoveTo(gameObject, posStart, 1.0f);
    }

    IEnumerator Move()
    {
        if (isMove)
        {
            isMove = false;
            yield return new WaitForSeconds(0.5f);
            GameController.Instance.isDone = true;
            StartMove();
            yield return new WaitForSeconds(1f);
            FoodOrder.Instance.DestroyChild();
            MoveBack();
            Debug.Log("Move");
        }
    }
}
