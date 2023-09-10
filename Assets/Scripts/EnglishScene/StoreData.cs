using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreData : MonoBehaviour
{
    [SerializeField] TextAsset _dataFile;

    public Dictionary<string, string> _dictionary = new Dictionary<string, string>();
    public List<string> _keyList = new List<string>();

    private void Start()
    {
        LoadDatabase();
        // foreach(var i in _dictionary)
        // {
        //     print($"{i.Key}: {i.Value}");
        // }
        
    }

    private void LoadDatabase()
    {
        if(_dataFile != null)
        {
            int i = 0;
            string[] line = _dataFile.text.Split("\n");
            foreach(string s in line)
            {
                string[] parts = s.Split(',');
                string word = parts[0].Trim();
                string meaning = parts[1].Trim();
                _dictionary[word] = meaning;
                _keyList.Add(word);
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
