using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreData : MonoBehaviour
{
    public Dictionary<string, string> _dictionary = new Dictionary<string, string>();
    public List<string> _keyList = new List<string>();

    private void Start()
    {
        

    }

    public void LoadDatabase(TextAsset dataFile)
    {
        string[] line = dataFile.text.Split("\n");
        foreach (string s in line)
        {
            string[] parts = s.Split(',');
            string word = parts[0].Trim();
            string meaning = parts[1].Trim();
            _dictionary[word] = meaning;
            _keyList.Add(word);
        }

        foreach(var i in _dictionary)
        {
            print($"{i.Key}: {i.Value}");
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
