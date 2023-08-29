using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class IOption : MonoBehaviour
{
    [SerializeField] int _tag;
    [SerializeField] GenerateEquation _equation;

    private void Start() {
        
    }

    public void CheckAnswer()
    {
        _equation.SpawnEquation(_tag);
    }

    

}
