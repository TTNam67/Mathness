using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EOption : MonoBehaviour
{
    [SerializeField] string _tag;
    [SerializeField] public Text _displayText;
    [SerializeField] public GameObject _isClicked;
    [SerializeField] int _index;
 

    public void CheckAnswer()
    {

        GenerateWords generateWords = GameObject.Find("GenerateWords").GetComponent<GenerateWords>();
        if (generateWords == null)
            Debug.LogError("GenerateWords is null");

        generateWords.CheckAnswer(this);
    }

    public void Ticked()
    {
        _isClicked.SetActive(true);
    }
    
    public void Unticked()
    {
        _isClicked.SetActive(false);
    }

    public string Tag
    {
        get { return _tag; }
        set { _tag = value; }
    }

    public void Reset()
    {
        
        _isClicked.SetActive(false);
    }

}
