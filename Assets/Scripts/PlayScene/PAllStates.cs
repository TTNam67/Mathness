using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FSM;

public class PAllStates : BaseState
{
    protected PStateMachine _pStateMachine;
    protected AudioSource _audioSource;
    protected GenerateEquation _generateEquation;
    protected Text _scoreText;
    protected Text _gameOverText;
    public PAllStates(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        _pStateMachine = (PStateMachine) stateMachine;
        _audioSource = _pStateMachine._audioSource;
        if (_audioSource == null)
            Debug.Log("AudioSource: " + _audioSource);
            
        _generateEquation = _pStateMachine._generateEquation; 
        if (_generateEquation == null)
            Debug.Log("GenerateEquation is null");

        _scoreText = _pStateMachine._scoreText;
        if (_scoreText == null)
           Debug.Log("Score Text: " + _scoreText);

        _gameOverText = _pStateMachine._gameOverText;
        if (_gameOverText == null){
            Debug.Log("GameOverText" + _gameOverText);
        }
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }
}
