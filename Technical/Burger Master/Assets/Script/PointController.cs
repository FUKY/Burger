using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointController : MonoSingleton<PointController> {

    public Text point;
    public Text pointDes;
    int scoreDes;
    int score = 0;
    LevelController levelController;
	// Use this for initialization
	void Start () {
        levelController = new LevelController();
        ShowPoint();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowPoint()
    {
        scoreDes = levelController.GetLevel() * 100;
        pointDes.text = scoreDes.ToString();
    }

    public void AddScore()
    {
        score += 10;
        point.text = score.ToString();
    }

    public void SetScore(int score)
    {
        this.score = score;
    }

    public int GetScore()
    {
        return this.score;
    }

    public void SetDes(int scoreDes)
    {
        this.scoreDes = scoreDes;
    }

    public int GetDes()
    {
        Debug.Log(this.scoreDes);
        return this.scoreDes;
    }

    public void ResetScore()
    {
        this.score = 0;
        point.text = this.score.ToString();
    }

    public bool CheckScore()
    {
        if (GetScore() >= GetDes())
        {
            return true;
        }
        return false;
    }
}
