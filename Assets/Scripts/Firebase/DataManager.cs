using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using ObserverPattern;

public class DataManager : MonoBehaviour
{
    DatabaseReference _databaseReference;
    string _userID;
    [SerializeField] InputField _nameField;
    [SerializeField] Text _notice;

    PStateMachine _pStateMachine;
    private PEStateMachine _pEStateMachine;

    GenerateEquation _generateEquation;
    GenerateWords _generateWords;
    int _sceneIndex;
    string _json;
    User _user;
    


    void Start()
    {
        SceneManager.sceneLoaded += OnSceceLoaded;
        DontDestroyOnLoad(this.gameObject);

        _userID = SystemInfo.deviceUniqueIdentifier;
        // Get the root reference location of the database.
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        

        // for (int i = 0; i < 1000000; i++)
        // {
        //     print("test");
        //     int a = 12;
        //     a += 0;
        // }
        //
        //
        // if (_sceneIndex == 1)
        // {
        //     _generateEquation = GameObject.Find("GenerateEquation").GetComponent<GenerateEquation>();
        //     if (_generateEquation != null)
        //         print("khong null");
        //
        //     _pStateMachine = GameObject.Find("Player").GetComponent<PStateMachine>();
        //     if (_pStateMachine != null)
        //         print("PstateMachine not null");
        //     
        //     _generateEquation.AddObserver(this);
        //
        //
        // }
        // else if (_sceneIndex == 2)
        // {
        //     _generateWords = GameObject.Find("GenerateWords").GetComponent<GenerateWords>();
        //     if (_generateWords!= null)
        //         print("khong null PE");
        //     
        //     _pEStateMachine = GameObject.Find("Player").GetComponent<PEStateMachine>();
        //     if (_pEStateMachine != null)
        //         print("PstateMachine not null");
        //     
        //     
        //
        //     _generateWords.AddObserver(this);
        // }

        
    }

    void OnSceceLoaded(Scene scene, LoadSceneMode mode)
    {
        print("cjhheck");
        int _sceneIndex = scene.buildIndex;
        // StartCoroutine(ConnectToPlayer());
    }
    
    

    

    

    // IEnumerator ConnectToPlayer()
    // {
    //     int i = 1;
    //     yield return new WaitForSeconds(0.9f);
    //     while (i > 0)
    //     {
    //         
    //         
    //
    //         i++;
    //     }
    //
    // }

    public void OnSubmit()
    {
        CreateNewUser(_userID, _nameField.text, 0, 0);
        
    }

    private void CreateNewUser(string userId, string name, int mathModePoints, int englishModePoints)
    {
        _user = new User(name, mathModePoints, englishModePoints);
        _json = JsonUtility.ToJson(_user);

        _databaseReference.Child("users").Child(userId).SetRawJsonValueAsync(_json);
        // _databaseReference.Child("users").Child(userId).Child("username").SetValueAsync(name);

        //Get the name
        StartCoroutine(GetName((string name) =>
        {
            _nameField.text =  name;
        }));

        // _notice.text = _databaseReference.Child("users").Child(userId).GetValueAsync();
    }

    public IEnumerator GetName(Action<string> onCallback)
    {
        var userNameData = _databaseReference.Child("users").Child(_userID).Child("username").GetValueAsync();

        yield return new WaitUntil(predicate: () => userNameData.IsCompleted);

        if (userNameData != null)
        {
            DataSnapshot snapshot = userNameData.Result;
            onCallback.Invoke(snapshot.Value.ToString());
        }
    }
}
