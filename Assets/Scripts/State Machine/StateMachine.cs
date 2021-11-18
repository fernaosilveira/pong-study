using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
   public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        RESET_GAME,
        END_GAME
    }
    public Dictionary<States, BaseState> dictionaryState;
    private BaseState currentState;
    public Player player;

    public static StateMachine Instance;



    private void Awake()
    {

        Instance = this;
        dictionaryState = new Dictionary<States, BaseState>();
        dictionaryState.Add(States.MENU, new BaseState());
        dictionaryState.Add(States.PLAYING, new PlayingState());
        dictionaryState.Add(States.RESET_POSITION, new ResetState());
        dictionaryState.Add(States.RESET_GAME, new ResetGameState());
        dictionaryState.Add(States.END_GAME, new EndGameState());

        SwitchStates(States.MENU);
    }

    private void SwitchStates(States state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }

        currentState = dictionaryState[state];

        if (currentState != null)
        {
            currentState.OnStateEnter();
        }
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnStateStay();
        }
    }

    public void ResetPosition()
    {
        SwitchStates(States.RESET_POSITION);
    }

    public void FinishGame()
    {
        SwitchStates(States.END_GAME);
    }

    public void PlayGame()
    {
        SwitchStates(States.PLAYING);
    }

    public void ResetGame()
    {
        SwitchStates(States.RESET_GAME);
    }

}
