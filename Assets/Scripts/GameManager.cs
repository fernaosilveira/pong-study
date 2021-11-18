using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallBase ballBase;
    public StateMachine stateMachine;
    public List<Player> players;
    public float timeToReleaseBall = 1.5f;
    public EndMenu endMenu;
    private bool isEndGame = (false);
    

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        if (!isEndGame)
        {
            Invoke(nameof(SetBallFree), timeToReleaseBall);
        }
       
    }

    public void SetBallFree()
    {
        ballBase.CanMove(true);
    }

    public void StartGame()
    {
        isEndGame = (false);
        ballBase.CanMove(false);
        Invoke(nameof(SetBallFree), timeToReleaseBall);
    }

    public void ExitGame()
    {

        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();

    }

    public void ResetGame()
    {
        isEndGame = (false);
        ResetBall();
        foreach (Player player in players)
        {
            player.ResetPlayer();
        }
    }

    public void EndGame()
    {
        foreach (Player player in players)
        {
            player.FinishMatch();
            endMenu.CheckWinner();

            if (player.currentPoints >= player.pointsToWin)
            {
                isEndGame = (true);
            }

        }
    }

}
