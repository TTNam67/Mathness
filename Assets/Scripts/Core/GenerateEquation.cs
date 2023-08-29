using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObserverPattern;

public enum GameState
{
    GameOver
}

public enum SFX
{
    Correct = 0,
    Wrong
}

public class GenerateEquation : MonoBehaviour
{
    int _1stNum, _2ndNum;
    [SerializeField] Text _equation;
    [SerializeField] Text _scoreText;
    [SerializeField] GameObject _gameOverScreen;
    [SerializeField] Text _gameOverText;

    [SerializeField] CountdownBar _countdownBar;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip[] _SFXs;


    int _logic;
    int _score = -1;
    void Start()
    {
        _logic = 1;
        _gameOverScreen.SetActive(false);
        SpawnEquation(1);

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.Log("Couldnt find AudioSource");
        }
    }

    // Update is called once per frame


    public void SpawnEquation(int tag)
    {

        CheckAnswer(tag);

        _1stNum = Random.Range(0, 100);
        _2ndNum = Random.Range(0, 100);
        _logic = Random.Range(0, 2);

        // The sign of the equation 
        int sign = Random.Range(-1, 1);
        if (sign > -1) sign = 1;
        string signText;
        if (sign == 1)
            signText = " + ";
        else
            signText = " - ";

        // if the equation is set to false
        int offset = 0;
        if (_logic == 0)
        {
            
            do 
            {
                offset = Random.Range(-10, 11);
            } 
            while (offset == 0);
        }

        int ans = _1stNum + sign * _2ndNum + offset;
        _equation.text = _1stNum.ToString() + signText + _2ndNum.ToString() + " = " + ans.ToString();
    }

    void CheckAnswer(int tag)
    {
        if (tag == _logic)
        {
            CorrectAnswer();
        }
        else
        {
            GameOver();
        }
    }

    public void CorrectAnswer()
    {
        _audioSource.clip = _SFXs[0];
        _audioSource.Play();
        _countdownBar.Reset();
        _score++;
        _scoreText.text = "Score = " + _score.ToString();
    }

    public void GameOver()
    {
        _audioSource.clip = _SFXs[1];
        _audioSource.Play();
        _gameOverScreen.SetActive(true);
        _gameOverText.text = "You Lose\n Your Score = " + _score.ToString();
        print("Thoat game");
    }

    

    
}
