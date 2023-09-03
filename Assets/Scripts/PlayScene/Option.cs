using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Option : MonoBehaviour
{
    [SerializeField] int _tag;
    [SerializeField] GenerateEquation _equation;

    private void Start() {
        
    }

    public void CheckAnswer()
    {
        _equation.CheckAnswer(_tag);
        _equation.SpawnEquation();
    }

    

}
