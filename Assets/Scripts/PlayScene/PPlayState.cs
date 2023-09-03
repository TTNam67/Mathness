using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FSM;


public class PPlayState : PAllStates
{
    public PPlayState(StateMachine stateMachine) : base("PPlayState", stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        _generateEquation.SpawnEquation();
        _scoreText.text = "Score = " + _pStateMachine.PlayerScore.ToString();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _scoreText.text = "Score = " + _pStateMachine.PlayerScore.ToString();

    }

    public override void Exit()
    {

    }
}
