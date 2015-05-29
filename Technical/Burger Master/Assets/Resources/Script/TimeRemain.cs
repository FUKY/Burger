using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeRemain : MonoSingleton<TimeRemain> {

    public Text textTime;
    public Image timeColor;
    float timeDecrease = 0;
    float timeCurrent = 10;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        CountDown();
        if (CheckTime())
        {
            LevelController.Instance.LevelUp();
            
        }
	}

    void CountDown()
    {
        if ((timeDecrease += Time.deltaTime) >= 1)
        {
            timeCurrent -= 1;
            textTime.text = timeCurrent.ToString();
            timeDecrease = 0;
        }
        timeColor.fillAmount -= (float)1 / (float)10 * Time.deltaTime;
    }

    public float GetTime()
    {
        return this.timeCurrent;
    }

    public void SetTime(float time)
    {
        this.timeCurrent = time;
    }

    public void ResetTime()
    {
        this.SetTime(10);
        timeColor.fillAmount = 1;
    }

    public bool CheckTime()
    {
        if (this.timeCurrent <= 0)
        {
            return true;
        }
        return false;
    }
}
