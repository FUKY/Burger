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
        iTween.MoveTo(gameObject, iTween.Hash(
            iT.MoveTo.position, tableContainer.transform.position,
            iT.MoveTo.time, 0.5f,
            iT.MoveTo.oncomplete, "MoveBack"));
    }

    void MoveBack()
    {
        FoodOrder.Instance.DestroyChild();
        iTween.MoveTo(gameObject, iTween.Hash(
            iT.MoveTo.position, posStart,
            iT.MoveTo.time, 0.5f,
            iT.MoveTo.oncomplete, "DoneEqualTrue"));
    }

    IEnumerator Move()
    {
        if (isMove)
        {
            isMove = false;
            yield return new WaitForSeconds(0.5f);
            StartMove();
            
        }
    }

    void DoneEqualTrue()
    {
        GameController.Instance.isDone = true;
    }
}
