using UnityEngine;
using System.Collections;

public class LevelController : MonoSingleton<LevelController> {

    int level;
    TimeRemain timeRemain;
    PointController pointController;
	// Use this for initialization
	void Start () {
        timeRemain = new TimeRemain();
        pointController = new PointController();
        PlayerPrefs.DeleteKey("level");
        GetLevel();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public int GetLevel()
    {
        if (!PlayerPrefs.HasKey("level"))
        {
            this.SetLevel(1);
            PlayerPrefs.SetInt("level", level);
        }
        else
        {
            this.SetLevel(PlayerPrefs.GetInt("level"));
        }
        return this.level;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public void LevelUp()
    {
        if (pointController.CheckScore())
        {
            this.level++;
            SetLevel(this.level);
            PlayerPrefs.DeleteKey("level");
            PlayerPrefs.SetInt("level", level);
            TimeRemain.Instance.ResetTime();
            PointController.Instance.ResetScore();
            PointController.Instance.ShowPoint();
            ButtonController.Instance.PassLevel();
        }
    }
}
