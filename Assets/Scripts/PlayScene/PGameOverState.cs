using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class PGameOverState : PAllStates
{
    public PGameOverState(StateMachine stateMachine) : base("PGameOverState", stateMachine)
    {

    }
    
    public override void Enter()
    {
        base.Enter();
        _gameOverText.text = "You Lose\n Your Score = " + _pStateMachine.PlayerScore.ToString();

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
