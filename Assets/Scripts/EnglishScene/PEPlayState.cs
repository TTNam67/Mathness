using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FSM;


public class PEPlayState : PEAllStates
{
    public PEPlayState(StateMachine stateMachine) : base("PEPlayState", stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        _generateWords.Generate();
        _scoreText.text = "Score = " + _pEStateMachine.PlayerScore.ToString();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _scoreText.text = "Score = " + _pEStateMachine.PlayerScore.ToString();
        if (_pEStateMachine.PlayerScore == _easyLevelPassScore)
        {
            _pEStateMachine.NotifyObservers(EPState.EASY_LEVEL_PASSED);
        }
        else if (_pEStateMachine.PlayerScore == _mediumLevelPassScore)
        {
            _pEStateMachine.NotifyObservers(EPState.MEDIUM_LEVEL_PASSED);
        }



    }

    public override void Exit()
    {

    }
}
