using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlStartScene : MonoBehaviour
{
    public Text startText; 

    private bool textVisible = true;

    private void Start()
    {
        
        startText.gameObject.SetActive(true);
        InvokeRepeating("ToggleTextVisibility", 0.5f, 0.5f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))      //Click mouse -> touch Screen
        {
            
            LoadGameScene();
        }
    }

    private void ToggleTextVisibility()
    {
       
        textVisible = !textVisible;
        startText.gameObject.SetActive(textVisible);
    }

    private void LoadGameScene()
    {
       
    }
}
