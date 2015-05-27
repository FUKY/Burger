using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FoodMove : MonoBehaviour
{

    public List<GameObject> FoodList;
    public RectTransform foodSize;
    public RectTransform posDisc;
    public Vector3 posDiscs;

    void Start()
    {
        posDiscs = new Vector3(posDisc.localPosition.x, posDisc.localPosition.y + posDisc.rect.height / 4, posDisc.localPosition.z);
    }

    [ContextMenu("Random Food")]
    public void RandomFood()
    {
        GameObject foodObj = Instantiate(FoodList[Random.Range(0, FoodList.Count)]);
        foodObj.GetComponent<RectTransform>().SetSize(foodSize.GetSize());
        foodObj.transform.SetParent(transform);
        foodObj.transform.localScale = Vector3.one;
        foodObj.transform.localPosition = new Vector3(posDiscs.x, posDiscs.y + 400, posDiscs.z);
        iTween.MoveTo(foodObj, iTween.Hash("position", posDiscs, "isLocal", true, "time", 2.0f, "easeType", iTween.EaseType.easeOutBack, "onComplete", "Complete"));
        posDiscs = new Vector3(posDiscs.x, posDiscs.y + foodObj.GetComponent<RectTransform>().rect.height / 4, posDiscs.z);
    }

    public void Complete()
    {

    }
}