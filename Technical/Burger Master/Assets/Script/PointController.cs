using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointController : MonoSingleton<PointController> {

    public Text point;
    int score = 0;
	// Use this for initialization
	void Start () {
        point.text = score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddScore()
    {
        score += 10;
        point.text = score.ToString();
    }
}
