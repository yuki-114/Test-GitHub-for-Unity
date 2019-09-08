using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonMonoBehaviour<UIManager>
{
    [SerializeField] GameObject startMessage;
    [SerializeField] GameObject endMessage;

    //void Start()
    //{
    //    startMessage.SetActive(true);
    //    endMessage.SetActive(false);
    //}


    public void StartUIUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.ChangeGameStatus(GameStatus.GamePlay);
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
