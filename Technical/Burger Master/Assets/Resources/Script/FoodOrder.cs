using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class FoodOrder : MonoBehaviour {

    public GameObject[] food = new GameObject[12];
    GameObject prefab;
    PrefabScript prefabScript;
    public SortedDictionary<int, GameObject> dictionary;
    int indexOfList;
    public int indexOfMenu;
    public Transform foodTransform;
    FixItem fix;
	// Use this for initialization
	void Start ()
    {
        fix = gameObject.GetComponent<FixItem>();
        dictionary = new SortedDictionary<int, GameObject>();
        CheckActive();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    //Cai ham checkActive nos goi truoc ham start cua thang nay luon
    void CheckActive()
    {
        CheckEnable checkEnable = null; //Như a nói, index của item em đặt giống của prefab, đặt khác là sai :D :D
        for (int i = 0; i < food.Length; i++)
        {
            checkEnable = food[i].GetComponent<CheckEnable>();
            if (checkEnable.isEnable)
            {
                prefab = Resources.Load<GameObject>("Prefab/Food/b_in" + checkEnable.index); //Để em check lại cái index mà em đã gán.
                dictionary.Add(checkEnable.index, prefab);
            }
        }
    }

    void RandomItem(int i)
    {
        //Cai nay ko lay phan tu theo index duoc. Vậy thì dùng cách nào lấy h a. Em có cuốn sách nói về Dictionary, để e mở coi thử.
        //hehe. ko duoc ak e.

        GameObject tranformParent;
        tranformParent = Instantiate(dictionary[dictionary.Keys.ElementAt(i)], transform.position, Quaternion.identity) as GameObject;
        tranformParent.transform.SetParent(foodTransform);
    }

    [ContextMenu("Random")]
    void RandomFood()
    {
        indexOfMenu = Random.Range(3, 7);
        fix.row = indexOfMenu; //Cái này là e gán cho nó có bao nhiêu hàng. Để cho nó fix với cái menu đó a.
        //Um a hieu roi, ma e phai goi lai cai ham fix thi no moi fix duoc chu. Đúng rồi. mà khi e làm vầy nha. Nó báo lỗi vào ngày hôm qua.
        //Cai nay hinh nhu a noi ko dung
        //Mỗi lần vào random nó sẽ gọi thằng này => Bỏ vào start?? //Bỏ vào start + khi nào lên level thì update và gọi lại để cập nhật OK.
        //Chi randdom trong cai
        //Hai doi tuong la cai đế bánh và cái nắp nó luôn luôn có nghe> OK.
        //Giờ e làm cái menu order đi, cho cả 3 trường hợp food - fooddrink-drink
        //E lam di, a lam viec ty. ^^.
        int prevIndex = -1;
        RandomItem(0);
        for (int i = 0; i < indexOfMenu - 2; i++)
        {
            indexOfList = Random.Range(1, dictionary.Count - 1);
            if (prevIndex == -1)
            {
                prevIndex = indexOfList;
                RandomItem(indexOfList);
            }
            else if (prevIndex != indexOfList)
            {
                prevIndex = indexOfList;
                RandomItem(indexOfList);
            }
            else
            {
                prevIndex = indexOfList;
                RandomItem(indexOfList);
            }
        }
        RandomItem(dictionary.Count - 1);
        fix.Fix();
        //Chổ này random:
        //Nếu ra 3 thì mình chỉ random 1 thằng giữa
        // > 3 thì random indexOfMenu - 2 phần tử
        // Công thức chung:
        //Gán thẳng thằng thứ 1 = cái đế bánh
        //Thằng cuối cùng = cái đầu bánh
        //Chỉ random khúc giữa

        //Như thế này thì không kiểm tra được 2 thằng kế nhau có giống nhau không
        //Anh đề xuất: Với mỗi Item thêm cho nó một cái ID:
        //ID = 1: Đế bánh
        ///ID = max: cái đầu bánh - cái nắp ak
        //ID = 1 < n < max là vi tri khuc giua

        //ID thằng trước = -1l;

            // 
            //if(thằng trước = -1)
            //thằng trước = indexOfList
            //else if(thằng trước != indexOfList)
            //thằng trước = indexOFList
            //else thằng trước = indexOfList
            //random lai cho den khi nào thằng trước khác indexOfList OK. Hiểu ý tưởng.
    }
}