using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    int gameScore =0;
    public int GameScore
    {
        get { return this.gameScore; }
    }


    //void Start()
    //{

    //}


    //void Update()
    //{

    //}


    public void AddScore(int GainScore)
    {
        gameScore += GainScore;
        UIManager.Instance.GameScore.text = "Score:" + gameScore;
    }
}
