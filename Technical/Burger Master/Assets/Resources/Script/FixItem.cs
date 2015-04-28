using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FixItem : MonoBehaviour {

    public int column = 1;
    public int row = 1;
    public GridLayoutGroup grid;
    public CheckType type;
    Vector2 size;
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
    public void Fix()
    {
        float width = gameObject.GetComponent<RectTransform>().rect.width;
        float height = gameObject.GetComponent<RectTransform>().rect.height;
        switch (type)
        {
            case CheckType.ngang:
                {
                    size.x = (width - grid.spacing.x * (column - 1)) / column;
                    size.y = (height - grid.spacing.y * (row - 1)) / row;
                    grid.cellSize = size;
                }
                break;
            case CheckType.ngangdoc:
                {
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
    ngangdoc = 1
}
