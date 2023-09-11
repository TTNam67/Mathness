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
    [SerializeField] Text[] _words;//list of words
    [SerializeField] Text[] _meanings; // list of meanings
    void Start()
    {
        _prevOption.Tag = "";
    }

    //Generate words when enter the game
    public void Generate()
    {
        //Temporarily contains the displaying words
        List <string> tmpKeyList = new List<string>();

        for (int i = 0; i < 5; i++)
        {
            int max = _data._keyList.Count;
            int tmp = Random.Range(0, max);
            _words[i].text = _data._keyList[tmp];
            tmpKeyList.Add(_words[i].text);
        }

        //Shuffle the keyList
        for (int i = 0; i < 5; i++) 
        {
            int j = Random.Range(0, 5);
            string temp = tmpKeyList[i];
            tmpKeyList[i] = tmpKeyList[j];
            tmpKeyList[j] = temp;
        }

        for (int i = 0; i < 5; i++)
        {
            _meanings[i].text = _data._dictionary[tmpKeyList[i]];
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
                _prevOption.Reset();
                _tmpTag = "";
                // _options[0].Reset();
            }
            // If 2 boxes are selected have different tags -> check the correctness
            else
            {   
                if (_data._dictionary.ContainsKey(_prevOption._displayText.text))
                {
                    if (_data._dictionary[_prevOption._displayText.text] == currentOption._displayText.text)
                    {
                        print("meaning matched 1st way");
                        NotifyObservers(EPState.GET_SCORE);
                    }
                }
                else if (_data._dictionary.ContainsKey(currentOption._displayText.text))
                {
                    if (_data._dictionary[currentOption._displayText.text] == _prevOption._displayText.text)
                    {
                        print("meaning matched 2nd way");
                        NotifyObservers(EPState.GET_SCORE);
                    }
                }
                else 
                {
                    print("no match");
                }
                _tmpTag = "";
                _prevOption.Reset();
                currentOption.Reset();
                // _prevOption = new EOption();
            }
        }


    }

    public void OnNotify(EPState pState)
    {

    }

    

}
