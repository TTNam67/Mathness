using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObserverPattern;

public class GenerateWords : Subject, IObserver
{
    [SerializeField] LoadData _data;

    EOption _prevOption = new EOption();
    string _tmpTag = "";
    [SerializeField] TextAsset _a1;
    [SerializeField] TextAsset _a2;
    [SerializeField] TextAsset _b1;
    [SerializeField] TextAsset _textAsset;
    [SerializeField] Text[] _words;//list of displaying words
    [SerializeField] Text[] _meanings; // list of displaying meanings
    [SerializeField] CountdownBarEnglish _countDownBarEnglish;
    [SerializeField] GameObject _gameOverScreen;
    int _totalWords;
    int _wordId = 5;
    void Start()
    {
        _gameOverScreen.SetActive(false);
        _prevOption.Tag = "";
        AddObserver(_countDownBarEnglish);

    }




    //Generate words when enter the game
    public void Generate()
    {
        //Temporarily contains the displaying words
        List<string> tmpKeyList = new List<string>();

        _totalWords = _data.GetWordData().Count;
        for (int i = 0; i < _wordId; i++)
        {
            _words[i].text = _data.GetWordData()[i];
            _meanings[i].text = _data.GetMeaningData()[i];
        }
    }

    public void CheckAnswer(EOption currentOption)
    {

        //If player havent selected any box -> tick the box player have just selected 
        if (_tmpTag == "")
        {
            _tmpTag = currentOption.Tag;
            _prevOption = currentOption;
            currentOption.Ticked();
            // _options.Add(eOption);
        }
        // If player have selected 1 box
        else if (_tmpTag != "")
        {
            //If 2 boxes that are selected have the same tag -> unticked 2 boxes
            if (_prevOption.Tag == currentOption.Tag)
            {
                print("tag is the same");
                _prevOption.Unticked();
                _tmpTag = "";
                // _options[0].Reset();
            }
            // If 2 boxes are selected have different tags -> check the correctness
            else
            {
                if (_prevOption.Tag == "m")
                {
                    Swap(ref _prevOption, ref currentOption);
                }

                if ((_data._dictionary.ContainsKey(_prevOption._displayText.text) && _data._dictionary[_prevOption._displayText.text] == currentOption._displayText.text))
                {
                    NotifyObservers(EPState.GET_SCORE);
                    _prevOption.Reset();
                    currentOption.Reset();

                    // Add new words
                    StartCoroutine(AddNewWords(currentOption));

                }
                else
                {
                    print("no match");
                }
                _tmpTag = "";
                _prevOption.Unticked();
                currentOption.Unticked();
                // _prevOption = new EOption();
            }
        }


    }

    IEnumerator AddNewWords(EOption currentOption)
    {
        yield return new WaitForSeconds(0.25f);
        _prevOption._displayText.text = _data.GetWordData()[_wordId];
        currentOption._displayText.text = _data.GetMeaningData()[_wordId];
        _wordId++;
    }

    public void OnNotify(EPState pState)
    {

    }

    public void Swap(ref EOption a, ref EOption b)
    {
        var tmp = a;
        a = b;
        b = tmp;
    }

    public void GameOver()
    {
        NotifyObservers(EPState.GAME_OVER);
        _gameOverScreen.SetActive(true);
        this.gameObject.SetActive(false);
        this.enabled = false;
    }


}
