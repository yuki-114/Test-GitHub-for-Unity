using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameStatus
{
    Start,
    GamePlay,
    End,
}


public class GameProcessManager : SingletonMonoBehaviour<GameProcessManager>
{
    GameStatus currentGameStatus;
    public GameStatus CurrentGameStatus
    {
        get { return this.currentGameStatus; }
    }

    [SerializeField] GameObject targetGenerator;


    void Start()
    {
        ChangeGameStatus(GameStatus.Start);
    }


    void Update()
    {
        switch (currentGameStatus)
        {
            case GameStatus.Start:
                StartProcess();
                break;

            case GameStatus.GamePlay:
                GamePlayProcess();
                break;

            case GameStatus.End:
                EndProcess();
                break;
        }
    }


    public void ChangeGameStatus(GameStatus nextStatus)
    {
        currentGameStatus = nextStatus;
        UIManager.Instance.ChangeMessage(nextStatus);

        switch (nextStatus)
        {
            case GameStatus.Start:
                targetGenerator.SetActive(false);
                break;

            case GameStatus.GamePlay:
                targetGenerator.SetActive(true);
                break;

            case GameStatus.End:
                targetGenerator.SetActive(false);
                break;
        }
    }


    void StartProcess()
    {
        UIManager.Instance.StartUIUpdate();
    }


    void GamePlayProcess()
    {
        Shooter.Instance.ShooterUpdate();
    }


    void EndProcess()
    {

    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
