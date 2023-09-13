using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ObserverPattern;

public class CountdownBarEnglish : MonoBehaviour, IObserver
{
    public Slider _slider;
    [SerializeField] Image _image;
    [SerializeField] GenerateWords _generateWords;
    Image _fillImage;
    // [SerializeField] Sprite[] _sprites;
    float _countdownMax = 2.5f;

    void Start()
    {
        _slider = GetComponent<Slider>();
        if (_slider == null)
            Debug.LogWarning("HealthBar.cs: Slider is null");
        
        

        _fillImage = transform.GetChild(0).GetComponent<Image>();

        _slider.maxValue = _countdownMax;
        _slider.value = _countdownMax;
    }

    private void Update()
    {

        _slider.value -= Time.deltaTime;
        if (_slider.value <= 0f )
        {
            _generateWords.GameOver();
        }

        _fillImage.color = Color.Lerp(Color.green, Color.red, CalculateSlider());
    }

    private float CalculateSlider()
    {
        // float a = _slider.maxValue;
        // float b = _slider.minValue;
        // float x = _slider.value;

        // float t = (x - a) / (b - a);
        // return t;

        float a = _countdownMax;
        float b = 0f;
        float x = _slider.value;

        float t = (x - a) / (b - a);
        return t;
    }

    public void SetMaxTime(float time)
    {
        _slider.maxValue = time;
    }

    public void Reset()
    {
        _slider.value = _countdownMax;
    }

    public void OnNotify(EPState pState)
    {
        if (pState == EPState.EASY_LEVEL_PASSED)
        {
            SetMaxTime(2.1f);
        }
        else if (pState == EPState.MEDIUM_LEVEL_PASSED)
        {
            SetMaxTime(1.5f);
        }
        else if (pState == EPState.HARD_LEVEL_PASSED)
        {
            SetMaxTime(1.2f);
        }
        else if (pState == EPState.GET_SCORE)
        {
            Reset();
        }
    }

}



