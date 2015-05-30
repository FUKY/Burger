using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointController : MonoSingleton<PointController> {

    public Text point;
    public Text rightQuest;
    int rightNumber;
    int wrongQuest = 0;
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
        rightNumber = levelController.GetLevel() * 5;
        Debug.Log(rightNumber);
        rightQuest.text = rightNumber.ToString();
        if (levelController.GetLevel() > 2)
        {
            wrongQuest = 3;
        }
    }

    public void WrongSub()
    {
        wrongQuest -= 1;
        point.text = wrongQuest.ToString();
    }

    public void RightSub()
    {
        rightNumber -= 1;
        rightQuest.text = rightNumber.ToString();
    }

    public void SetScore(int score)
    {
        this.wrongQuest = score;
    }

    public int GetScore()
    {
        return this.wrongQuest;
    }

    public void SetDes(int scoreDes)
    {
        this.rightNumber = scoreDes;
    }

    public int GetDes()
    {
        return this.rightNumber;
    }

    public void ResetScore()
    {
        this.wrongQuest = 0;
        point.text = this.wrongQuest.ToString();
        rightNumber = levelController.GetLevel() * 5;
        rightQuest.text = rightNumber.ToString();
    }

    public bool CheckScore()
    {
        if (GetDes() <= 0)
        {
            SetDes(0);
            rightQuest.text = rightNumber.ToString();
            return true;
        }
        return false;
    }
}
