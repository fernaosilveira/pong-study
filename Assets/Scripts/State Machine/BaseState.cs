using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{
   public virtual void OnStateEnter(object o = null)
    {

    }

    public virtual void OnStateStay()
    {

    }

    public virtual void OnStateExit()
    {

    }
}

public class PlayingState : BaseState
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        BallBase b = (BallBase)o;
        GameManager.Instance.StartGame();

    }
}

public class ResetState : BaseState
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.Instance.ResetBall();

    }
}

public class ResetGameState : BaseState
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.Instance.ResetGame();

    }
}

public class EndGameState : BaseState
{
    public override void OnStateEnter(object o = null)
    {
        base.OnStateEnter(o);
        GameManager.Instance.EndGame();

    }
}
