using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeRemain : MonoSingleton<TimeRemain> {

    public Text textTime;
    public Image timeColor;
    float second;
    float timeDecrease = 0;
    float timeCurrent = 60;
	// Use this for initialization
	void Start () {
        second = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if ((timeDecrease += Time.deltaTime) >= second)
        {
            if (timeCurrent <= 0)
            {
                timeCurrent = 60;
                timeColor.fillAmount = 1;
            }
            timeCurrent -= second;
            textTime.text = timeCurrent.ToString();
            timeDecrease = 0;
        }
        timeColor.fillAmount -= (float)1 / (float)60 * Time.deltaTime;
	}
}
