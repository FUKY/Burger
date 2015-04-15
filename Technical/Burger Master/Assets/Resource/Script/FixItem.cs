using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FixItem : MonoBehaviour {

    public int column = 1;
    public int row = 1;
    public GridLayoutGroup grid;
    public CheckType type;
    public float width;
    public float height;
    Vector2 size;
    FoodOrder foodOrder;
	// Use this for initialization
	void Start ()
    {
        Fix();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}
    //Dùng scale item theo column
    
    [ContextMenu("Fix")]
    void Fix()
    {
        switch (type)
        {
            case CheckType.ngang:
                {
                    width = gameObject.GetComponent<RectTransform>().rect.width;
                    height = gameObject.GetComponent<RectTransform>().rect.height;
                    size.x = (width - grid.spacing.x * (column - 1)) / column;
                    size.y = (height - grid.spacing.y * (row - 1)) / row;
                    grid.cellSize = size;
                }
                break;
            case CheckType.ngangdoc:
                {
                    width = gameObject.GetComponent<RectTransform>().rect.width;
                    size.x = (width - grid.spacing.x * (column - 1)) / column;
                    size.y = size.x;
                    grid.cellSize = size;
                }
                break;
            case CheckType.menu:
                {
                    row = foodOrder.indexOfMenu;
                    width = gameObject.GetComponent<RectTransform>().rect.width;
                    size.x = (width - grid.spacing.x * (column - 1)) / column;
                    size.y = size.x;
                    grid.cellSize = size;
                }
                break;
            default:
                break;
        }
    }
}

public enum CheckType {
    ngang = 0,
    ngangdoc = 1,
    menu = 2
}
