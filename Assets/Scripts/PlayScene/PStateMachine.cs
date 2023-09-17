using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObserverPattern;
using Firebase;
using Firebase.Database;
using System;

using FSM;

public class PStateMachine : StateMachine, IObserver
{
    
    [HideInInspector] public PPlayState _pPlayState;
    [HideInInspector] public PGameOverState _pGameOverState;

    public AudioSource _audioSource;
    public AudioClip[] _sFXClips;
    public GenerateEquation _generateEquation;
    public Text _scoreText;
    public Text _gameOverText;
    public BackgroundMusic _backgroungMusic;
    public int _playerScore = 0;
    string _userID;
    DatabaseReference _databaseReference;

    public int _prevScore = 0;
    
    

    private void Awake()
    {
        _userID = SystemInfo.deviceUniqueIdentifier;
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.Log("AudioSource: " + _audioSource);

        // _generateEquation = GameObject.Find("Equation").GetComponent<GenerateEquation>();
        // if (_generateEquation == null)
        //     Debug.Log("GenerateEquation: " + _generateEquation);

        _scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        if (_scoreText == null)
           Debug.Log("Scoretext" + _scoreText);
        
        AddObserver(_generateEquation);
        AddObserver(_backgroungMusic);
        _generateEquation.AddObserver(this);
        

        _pPlayState = new PPlayState(this);
        _pGameOverState = new PGameOverState(this);
    }


    protected override BaseState GetInitialState()
    {
        return _pPlayState;
    }

    public void OnNotify()
    {

    }

    public void OnNotify(EPState pState)
    {
        if (pState == EPState.GET_SCORE)
        {
            
            _audioSource.clip = _sFXClips[(int)ESFX.GETSCORE];
            _audioSource.volume = .55f;
            _audioSource.Play();
            _playerScore++;
            
        }
        else if (pState == EPState.GAME_OVER)
        {
            ChangeState(_pGameOverState);
            int _prevScore;
            
            _databaseReference.Child("users").Child(_userID).Child("mathModePoints").SetValueAsync((int)_playerScore);
        }
    }   
    
   

    // override public string ToString()
    // {
    //     return "psm";
    // }

    public int PlayerScore
    {
        get { return _playerScore; }
        set { _playerScore = value; }
    }

}
