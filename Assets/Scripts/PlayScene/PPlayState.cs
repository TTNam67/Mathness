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
        if (_pStateMachine.PlayerScore == _easyLevelPassScore)
        {
            _pStateMachine.NotifyObservers(EPState.EASY_LEVEL_PASSED);
        }
        else if (_pStateMachine.PlayerScore == _mediumLevelPassScore)
        {
            _pStateMachine.NotifyObservers(EPState.MEDIUM_LEVEL_PASSED);
        }
        else if (_pStateMachine.PlayerScore == _hardLevelPassScore)
        {
            _pStateMachine.NotifyObservers(EPState.HARD_LEVEL_PASSED);
        }


    }

    public override void Exit()
    {

    }
}
