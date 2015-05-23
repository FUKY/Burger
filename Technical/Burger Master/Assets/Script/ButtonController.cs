using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

    public GameObject gameMain;
    public GameObject gameStart;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayClick()
    {
        gameMain.SetActive(true);
        gameStart.SetActive(false);
    }

    public void SettingClick()
    {

    }

    public void AboutClick()
    {

    }

    public void ExitClick()
    {

    }
}
