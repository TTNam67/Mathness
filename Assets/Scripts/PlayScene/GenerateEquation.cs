using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObserverPattern;

public class GenerateEquation : Subject, IObserver
{
    int _1stNum, _2ndNum;
    [SerializeField] Text _equation;
    [SerializeField] Text _scoreText;
    [SerializeField] Text _gameOverText;
    [SerializeField] GameObject _gameOverScreen;
    [SerializeField] CountdownBar _countdownBar;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _loseSFX;
    [SerializeField] AudioClip _correctSFX;


    int _correctness;
    void Start()
    {
        _gameOverScreen.SetActive(false);
        // SpawnEquation(1);

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.Log("Couldnt find AudioSource");
        }

        // _observers.ForEach((_observer) =>
        // {
        //    Debug.Log(_observer.ToString());
        // });
    }



    public void SpawnEquation()
    {
        _1stNum = Random.Range(0, 100);
        _2ndNum = Random.Range(0, 100);
        _correctness = Random.Range(0, 2);

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
        if (_correctness == 0)
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

    public void CheckAnswer(int tagOfAnswer)
    {
        if (tagOfAnswer == _correctness)
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
        Debug.Log("correct");
        _audioSource.PlayOneShot(_correctSFX);
        _countdownBar.Reset();
        NotifyObservers(EPState.GETSCORE); 
    }

    public void GameOver()
    {
        _audioSource.clip = _loseSFX;
        _audioSource.Play();
        // _audioSource.PlayOneShot(_loseSFX);
        _gameOverScreen.SetActive(true);
        NotifyObservers(EPState.GAMEOVER);
        this.gameObject.SetActive(false);
        this.enabled = false;
    }

    public void OnNotify(EPState pState)
    {
        
    }

    
    public void NotifyObservers(EPState pState)
    {
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify(pState);
        });
    }
    




}
