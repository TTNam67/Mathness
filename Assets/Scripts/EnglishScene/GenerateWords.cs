using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObserverPattern;

public class GenerateWords : Subject, IObserver
{
    [SerializeField] LoadData _data;
    string _tag1 = "";
    string _tag2 = "";
    [SerializeField] TextAsset _a1;
    [SerializeField] TextAsset _a2;
    [SerializeField] TextAsset _b1;
    [SerializeField] TextAsset _textAsset;
    [SerializeField] Text[] _words;
    [SerializeField] Text[] _meanings;
    void Start()
    {
        
    }

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

    public void CheckAnswer(string tag)
    {
        //If player havent selected any box -> tick the box player have just selected 
        if (_tag1 == "")
        {
            _tag1 = tag;
        }
        // If player have selected 1 box
        else if (_tag1 != "" && _tag2 == "")
        {
            //If 2 boxes that are selected have the same tag -> unticked 2 boxes
            if (_tag1 == tag)
            {

            }
            // If 2 boxes are selected have different tags -> check the correctness
            else
            {

            }
        }


    }

    public void OnNotify(EPState pState)
    {

    }

    

}
