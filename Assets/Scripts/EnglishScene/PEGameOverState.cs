using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class PEGameOverState : PEAllStates
{
    public PEGameOverState(StateMachine stateMachine) : base("PEGameOverState", stateMachine)
    {

    }
    
    public override void Enter()
    {
        base.Enter();
        _gameOverText.text = "You Lose\n Your Score = " + _pEStateMachine.PlayerScore.ToString();
        _audioSource.clip = _sFXClips[(int)ESFX.GAMEOVER];
        _audioSource.Play();

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _audioSource.Stop();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
