using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;

public class TestFirebase : MonoBehaviour
{
    DatabaseReference _databaseReference;
    string _userID;
    [SerializeField] InputField _nameField;
    [SerializeField] Text _notice;
    void Start()
    {
        _userID = SystemInfo.deviceUniqueIdentifier;
        // Get the root reference location of the database.
        _databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        

    }

    public void OnSubmit()
    {
        CreateNewUser(_userID, _nameField.text, "Email123");
        
    }

    private void CreateNewUser(string userId, string name, string email)
    {
        User user = new User(name, email);
        string json = JsonUtility.ToJson(user);

        _databaseReference.Child("users").Child(userId).SetRawJsonValueAsync(json);

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
