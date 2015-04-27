using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FoodOrder : MonoSingleton<FoodOrder> 
{
    public List<GameObject> foodItem = new List<GameObject>(); //List chứa các item bên dưới
    List<int> listIndex = new List<int>(); //List chứa các index của các prefab
    public List<GameObject> listPrefab = new List<GameObject>(); //List chứa tất cả các prefab
    public List<GameObject> listCheck = new List<GameObject>(); //List chứa các index của các item đã được random trên menu

    public GameObject parentTrans;
    public GameObject scaleParent;
    void Start()
    {
        CheckActive();
    }

    void CheckActive()
    {
        CheckEnable checkEnable = null;
        for (int i = 0; i < foodItem.Count; i++)
        {
            checkEnable = foodItem[i].GetComponent<CheckEnable>();
            if (checkEnable.isEnable)
            {
                listIndex.Add(checkEnable.index);
            }
        }
    }

    void Instan(GameObject gObject)
    {
        GameObject trans;
        trans = Instantiate(gObject, transform.position, Quaternion.identity) as GameObject;
        RectExtension.SetSize(trans.GetComponent<RectTransform>(), Resize(ref gObject));
        trans.transform.SetParent(parentTrans.transform);
    }

    [ContextMenu("Test")]
    void RandomItem()
    {
        int indexOfMenu = Random.Range(3, 7);
        for (int i = 0; i < indexOfMenu; i++)
        {
            int indexOfList = Random.Range(0, listIndex.Count);
            Instan(listPrefab[listIndex[indexOfList] - 1]);
            listCheck.Add(listPrefab[listIndex[indexOfList] - 1]);
        }
    }

    Vector2 Resize(ref GameObject gObject)
    {
        Vector2 curSize, newSize;
        float width = scaleParent.GetComponent<RectTransform>().rect.width / 2 * 0.8f;
        curSize = gObject.GetComponent<RectTransform>().rect.size;
        float ratio = curSize.x / width;
        newSize.x = width;
        newSize.y = curSize.y / ratio;
        return newSize;
    }
}
