using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    [SerializeField] TextAsset _dataFile;

    private Dictionary<string, string> _dictionary = new Dictionary<string, string>();

    private void Start()
    {
        LoadDatabase();
        foreach(var i in _dictionary)
        {
            print($"{i.Key}: {i.Value}");
        }
        
    }

    private void LoadDatabase()
    {
        if(_dataFile != null)
        {
            string[] line = _dataFile.text.Split("\n");
            foreach(string s in line)
            {
                string[] parts = s.Split(',');
                if (parts.Length == 2)
                {
                    string word = parts[0].Trim();
                    string meaning = parts[1].Trim();
                    _dictionary[word] = meaning;
                }
            }
        }
        else
        {
            Debug.LogError("Database file not assigned!");
        }
    }
    public string GetMeaning(string word)
    {
        if (_dictionary.ContainsKey(word))
        {
            return _dictionary[word];
        }
        else
        {
            return "Word not found in the database";
        }
    }
}
