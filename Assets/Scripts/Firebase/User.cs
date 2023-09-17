using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User 
{
    public string username;
    public int mathModePoints;
    public int englishModePoints;

    public User() {
    }

    public User(string username, int mathModePoints, int englishModePoints) {
        this.username = username;
        this.mathModePoints = mathModePoints;
        this.englishModePoints = englishModePoints;
    }
}