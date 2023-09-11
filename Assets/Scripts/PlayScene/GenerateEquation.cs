using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObserverPattern;

public class GenerateEquation : Subject, IObserver
{
    public enum WrongMechanism
    {
        OFFSET_EQUAL_3,
        CHANGE_THE_SIGN,
        CHANGE_THE_CALCULATION,
        FORGOT_THE_10,
        SWAP_UNIT_ROW,
        
    }

    public enum Sign
    {
        NEGATIVE = 0,
        POSITVE = 1
    }

    public enum TagOfAnswer
    {
        FALSE = 0,
        TRUE = 1
    }

    public enum ECurrentLevel
    {
        EASY = 0,
        MEDIUM,
        HARD,
        INSANE
    }


    
    [SerializeField] Text _equation;
    [SerializeField] Text _scoreText;
   
    [SerializeField] CountdownBar _countdownBar;
    [SerializeField] AudioSource _audioSource;

    [Header("Game Over Screen")]
    [SerializeField] Text _gameOverText;
    [SerializeField] GameObject _gameOverScreen;

    int _currentLevel = (int)ECurrentLevel.EASY;
    int _easyLevelPlusRange = 20;
    int _mediumLevelPlusRange = 40;
    int _hardLevelPlusRange = 60;
    int _hardLevelMultiplyRange = 11;
    int _insaneLevelMultiplyRange = 15;
    int _numberOfWrongs = 5;

    int _1stNum, _2ndNum, _ans; // for the equation
    int _maxPlusNum, _maxMultiplyNum;

    int _cntCorrectness = 0, _maxCorrectnessSequence = 4;

    int _correctness;
    void Start()
    {
        _gameOverScreen.SetActive(false);

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.Log("Couldnt find AudioSource");
        }

        _maxPlusNum =  _easyLevelPlusRange;
        

    }



    public void SpawnEquation()
    {
        _correctness = Random.Range(0, _numberOfWrongs + 4);
        CheckCorrectnessSequence();
        
        int isMultiplyEquation = Random.Range(0, 5);
        // Multiply equation
        if (isMultiplyEquation > 1 && _currentLevel >= 2)
        {
            _1stNum = Random.Range(0, _maxMultiplyNum);
            _2ndNum = Random.Range(0, _maxMultiplyNum);
            _ans = _1stNum * _2ndNum;


            if (_correctness == (int)WrongMechanism.CHANGE_THE_SIGN && _ans != 0)
            {
                _ans = -_ans;
            }
            else if (_correctness == (int)WrongMechanism.FORGOT_THE_10)
            {
                _ans -= 10;
            }
            else if (_correctness == (int)WrongMechanism.OFFSET_EQUAL_3)
            {
                int offset = 0;
                do
                {
                    offset = Random.Range(-3, 4);
                }
                while (offset == 0);
                _ans += offset;
            }
            else if (_correctness == (int)WrongMechanism.CHANGE_THE_CALCULATION)
            {
                // _ans = 99999;
                _ans -= 1;
                
            }
            else if (_correctness == (int)WrongMechanism.SWAP_UNIT_ROW)
            {
                _ans -= 1;
                // _ans = 99999;
            }
            else 
            {
                _correctness = 9;
            }
            _equation.text = _1stNum.ToString() + " * " + _2ndNum.ToString() + " = " + _ans.ToString();
        }
        else 
        {
            _1stNum = Random.Range(0, _maxPlusNum);
            _2ndNum = Random.Range(0, _maxPlusNum);

            // The sign of the equation 
            int sign = Random.Range(0, 2);
            string signText;
            if (sign == (int)Sign.POSITVE)
            {
                signText = " + ";
            }            
            else
            {
                signText = " - ";
                _2ndNum *= -1;
            }

            _ans = _1stNum + _2ndNum;

            

            // if the equation is set to false
            if (_correctness == (int)WrongMechanism.CHANGE_THE_SIGN && _ans != 0)
            {
                _ans = -_ans;
            }
            else if (_correctness == (int)WrongMechanism.FORGOT_THE_10)
            {
                _ans -= 10;
            }
            else if (_correctness == (int)WrongMechanism.OFFSET_EQUAL_3)
            {
                int offset = 0;
                do
                {
                    offset = Random.Range(-3, 4);
                }
                while (offset == 0);
                _ans += offset;
            }
            else if (_correctness == (int)WrongMechanism.CHANGE_THE_CALCULATION)
            {
                // _ans = 99999;
                _ans -= 1;
                
            }
            else if (_correctness == (int)WrongMechanism.SWAP_UNIT_ROW)
            {
                _ans -= 1;
                // _ans = 99999;
            }
            else 
            {
                _correctness = 9;
            }

            _equation.text = _1stNum.ToString() + signText + Mathf.Abs(_2ndNum).ToString() + " = " + _ans.ToString();
        }
        
        Debug.Log(_equation.text);
    }


    



    public void CheckAnswer(int tagOfAnswer)
    {
        Debug.Log("tag" + tagOfAnswer + ", correct" + _correctness);
        if ((tagOfAnswer == (int)TagOfAnswer.TRUE && (_correctness > (_numberOfWrongs - 1)))
        || (tagOfAnswer == (int)TagOfAnswer.FALSE && (_correctness < _numberOfWrongs)))
        {
            CorrectAnswer();
        }
        else
        {
            GameOver();
        }
    }

    public void CheckCorrectnessSequence()
    {
        //If right sequence is too long -> make sure this equation is wrong
        if (_cntCorrectness >= _maxCorrectnessSequence)
        {   
            _correctness = Random.Range(0, _numberOfWrongs);
        }// If wrong sequence is too long -> .. right
        else if (_cntCorrectness <= -_maxCorrectnessSequence)
        {
            _correctness = _numberOfWrongs;
        }

        //If the current equation is not correct
        if (_correctness < _numberOfWrongs)
        {
            _cntCorrectness--;
        }
        else _cntCorrectness++;
    }

    public void CorrectAnswer()
    {
        // Debug.Log("GenerateEquation: CorrectAnswer()");
        NotifyObservers(EPState.GET_SCORE);
        _countdownBar.Reset();
        
    }

    public void GameOver()
    {
        NotifyObservers(EPState.GAME_OVER);
        _gameOverScreen.SetActive(true);
        this.gameObject.SetActive(false);
        this.enabled = false;
    }

    public void OnNotify(EPState pState)
    {
        if (pState == EPState.EASY_LEVEL_PASSED)
        {
            _currentLevel = (int)ECurrentLevel.MEDIUM;
            _maxPlusNum = _mediumLevelPlusRange;
            _maxMultiplyNum = _hardLevelMultiplyRange;
            Debug.Log("Pass easy");

        }
        else if (pState == EPState.MEDIUM_LEVEL_PASSED)
        {
            _currentLevel = (int)ECurrentLevel.HARD;
            _maxPlusNum = _hardLevelPlusRange;
            _maxMultiplyNum = _hardLevelMultiplyRange;
            Debug.Log("Pass medium");
        }
        else if (pState == EPState.HARD_LEVEL_PASSED)
        {
            _currentLevel = (int)ECurrentLevel.INSANE;
            _maxMultiplyNum = _insaneLevelMultiplyRange;
            Debug.Log("Pass hard");
        }
    }

    
    // public void NotifyObservers(EPState pState)
    // {
    //     _observers.ForEach((_observer) =>
    //     {
    //         _observer.OnNotify(pState);
    //     });
    // }
    




}
