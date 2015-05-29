using UnityEngine;
using System.Collections;

public class ButtonController : MonoSingleton<ButtonController> {

    public GameObject gameMain;
    public GameObject gameStart;
    public GameObject gameSetting;
    public GameObject aboutUs;
    public GameObject gamePass;
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
        Application.Quit();
    }

    public void PassLevel()
    {
        gameMain.SetActive(false);
        gamePass.SetActive(true);
    }

    public void ContinueClick()
    {
        gamePass.SetActive(false);
        gameMain.SetActive(true);
    }

    public void MainMenuClick()
    {
        gameStart.SetActive(true);
        gamePass.SetActive(false);
    }
}
