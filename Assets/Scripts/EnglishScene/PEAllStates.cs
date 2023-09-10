using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FSM;

public class PEAllStates : BaseState
{
    protected PEStateMachine _pEStateMachine;
    protected AudioSource _audioSource;
    protected AudioClip[] _sFXClips;
    protected GenerateWords _generateWords;
    protected Text _scoreText;
    protected Text _gameOverText;

    protected int _easyLevelPassScore = 3;
    protected int _mediumLevelPassScore = 6;
    public PEAllStates(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        _pEStateMachine = (PEStateMachine) stateMachine;

        _audioSource = _pEStateMachine._audioSource;
        if (_audioSource == null)
            Debug.Log("AudioSource: " + _audioSource);

        _sFXClips = _pEStateMachine._sFXClips;
        if (_sFXClips == null)
            Debug.Log("SFXClips: " + _sFXClips);

        _generateWords = _pEStateMachine._generateWords; 
        if (_generateWords == null)
            Debug.Log("GenerateEquation is null");

        _scoreText = _pEStateMachine._scoreText;
        if (_scoreText == null)
           Debug.Log("Score Text: " + _scoreText);

        _gameOverText = _pEStateMachine._gameOverText;
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
