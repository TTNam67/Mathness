using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObserverPattern;
using Firebase;
using Firebase.Database;

using FSM;

public class PEStateMachine : StateMachine, IObserver
{
    
    [HideInInspector] public PEPlayState _pEPlayState;
    [HideInInspector] public PEGameOverState _pEGameOverState;

    public AudioSource _audioSource;
    public AudioClip[] _sFXClips;
    public GenerateWords _generateWords;
    public Text _scoreText;
    public Text _gameOverText;
    public int _playerScore = 0;
    
    string _userID;
    DatabaseReference _databaseReference;
    

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
        
        AddObserver(_generateWords);
        
        _generateWords.AddObserver(this);

        _pEPlayState = new PEPlayState(this);
        _pEGameOverState = new PEGameOverState(this);
    }


    protected override BaseState GetInitialState()
    {
        return _pEPlayState;
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
            _databaseReference.Child("users").Child(_userID).Child("mathModePoints").SetValueAsync((int)_playerScore);
        }
        else if (pState == EPState.GAME_OVER)
        {
            ChangeState(_pEGameOverState);
            
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
