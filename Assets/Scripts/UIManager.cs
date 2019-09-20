using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField] GameObject startMessage;
    [SerializeField] GameObject endMessage;

    public Text GameScore;


    public void StartUIUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameProcessManager.Instance.ChangeGameStatus(GameStatus.GamePlay);
        }
    }


    public void ChangeMessage(GameStatus nextStatus)
    {
        switch (nextStatus)
        {
            case GameStatus.Start:
                startMessage.SetActive(true);
                endMessage.SetActive(false);
                break;

            case GameStatus.GamePlay:
                startMessage.SetActive(false);
                endMessage.SetActive(false);
                break;

            case GameStatus.End:
                startMessage.SetActive(false);
                endMessage.SetActive(true);
                break;
        }
    }
}
