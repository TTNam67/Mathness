using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FSM;

public class PAllStates : BaseState
{
    protected PStateMachine _pStateMachine;
    protected AudioSource _audioSource;
    protected AudioClip[] _sFXClips;
    protected GenerateEquation _generateEquation;
    protected Text _scoreText;
    protected Text _gameOverText;

    protected int _easyLevelPassScore = 3;
    protected int _mediumLevelPassScore = 6;
    protected int _hardLevelPassScore = 9;
    public PAllStates(string name, StateMachine stateMachine) : base(name, stateMachine)
    {
        _pStateMachine = (PStateMachine) stateMachine;

        _audioSource = _pStateMachine._audioSource;
        if (_audioSource == null)
            Debug.Log("AudioSource: " + _audioSource);

        _sFXClips = _pStateMachine._sFXClips;
        if (_sFXClips == null)
            Debug.Log("SFXClips: " + _sFXClips);
            
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
