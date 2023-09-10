using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverPattern;

public class GenerateWords : Subject, IObserver
{
    StoreData _data;
    string _tag1 = "";
    string _tag2 = "";
    void Start()
    {
        
    }

    public void Generate()
    {

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
