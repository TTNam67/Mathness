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
        _audioSource.clip = _sFXClips[(int)ESFX.GAMEOVER];
        _audioSource.Play();

    }

    public override void UpdateLogic()
    {
        _audioSource.Stop();
        base.UpdateLogic();
    }

    public override void Exit()
    {
        base.Exit();
    }
}
