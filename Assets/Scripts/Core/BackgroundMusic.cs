using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObserverPattern;

public class BackgroundMusic : MonoBehaviour, IObserver
{
    public enum EBackgroundClip
    {
        CONGRATULATION,
        EASY1,
        MEDIUM1,
        MEDIUM2,
    }

    public static BackgroundMusic _instance;

    AudioSource _audioSource;
    [SerializeField] AudioClip[] _backgroundClips;
    [SerializeField] AudioClip _congratulationSFX;
    float _backgroundMusicVolume = 0.60f;
    
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            Debug.LogWarning("SoundController.cs: AudioSource is not found");

        _audioSource.clip = _backgroundClips[(int)EBackgroundClip.EASY1];
        _audioSource.volume = _backgroundMusicVolume;
        _audioSource.Play();

    }

    public void OnNotify(EPState pState)
    {
        // if (pState == EPState.EASY_LEVEL_PASSED && _passEasyLevel == false)
        // {
        //     _passEasyLevel = true;
        //     Debug.Log("Before");
        //     StartCoroutine(PassEasyLevel());
        //     // _audioSource.Stop();
        //     // _audioSource.clip = _backgroundClips[(int)EBackgroundClip.MEDIUM1];
        //     // _audioSource.Play();
        //     Debug.Log("After");
        // }
    }

    // IEnumerator PassEasyLevel()
    // {
    //     _audioSource.Stop();
    //     _audioSource.clip = _backgroundClips[(int)EBackgroundClip.CONGRATULATION] ;
    //     _audioSource.Play();
    //     yield return new WaitForSeconds(3);
    //     _audioSource.clip = _backgroundClips[(int)EBackgroundClip.MEDIUM1];
    //     _audioSource.Play();
    // }


}
