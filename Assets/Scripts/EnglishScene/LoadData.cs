using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    [SerializeField] private TextAsset _dataFile;

    public Dictionary<string, string> _dictionary = new Dictionary<string, string>();
    public List<string> _wordData = new List<string>();
    public List<string> _meaningData = new List<string>();
    int _wordNum;

    private void Start()
    {
        LoadDatabase(_dataFile);
        // foreach(var i in _dictionary)
        // {
        //     print($"{i.Key}: {i.Value}");
        // }
    }

    private void LoadDatabase(TextAsset dataFile)
    {
        if(dataFile != null)
        {
            string[] line = dataFile.text.Split("\n");
            foreach(string s in line)
            {
                string[] parts = s.Split(',');
                if (parts.Length == 2)
                {
                    string word = parts[0].Trim();
                    string meaning = parts[1].Trim();
                    _dictionary[word] = meaning;
                    _wordData.Add(word);
                    _meaningData.Add(meaning);
                }
            }
        }
        else
        {
            Debug.LogError("Database file not assigned!");
        }

        _wordNum = _wordData.Count;
        Shuffle();

        
    }

    public void Shuffle()
    {
        // Shuffle all the words
        for (int i = 0; i < _wordNum; i++) 
        {
            int j = Random.Range(5, _wordNum);
            Swap2Elements(_meaningData, i, j);
            Swap2Elements(_wordData, i, j);
        }

        //Shuffle meaning of 5s first words
        for (int i = 0; i < 5; i++)
        {
            int j = Random.Range(0, 5);
            Swap2Elements(_meaningData, i, j);
        }

        
        //Shuffle meaning of remain words
        for (int i = 5; i < _wordNum; i += 2)
        {
            int opt = Random.Range(0, 4);
            if (opt == 0)
            {
                Swap2Elements(_meaningData, i, i + 1);
                Swap2Elements(_meaningData, i + 1, i + 2);
                i += 1;
            }
            else if (opt == 1)
            {
                Swap2Elements(_meaningData, i, i + 1);
            }
            
        }
    }

    public static void Swap2Elements<T>(List<T> list, int index1, int index2)
    {
        T temp = list[index1];
        list[index1] = list[index2];
        list[index2] = temp;
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

    public List<string> GetWordData()
    {
        return _wordData;
    }

    public List <string> GetMeaningData()
    {
        return _meaningData;
    }

    public int TotalWord()
    {
        return _wordNum;
    }
}
