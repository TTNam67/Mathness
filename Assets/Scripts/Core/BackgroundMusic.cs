using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class BackgroundMusic : MonoBehaviour
    {
        //private static MainMenuBackgroundMusic _instance;
        //public static MainMenuBackgroundMusic Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new MainMenuBackgroundMusic();
        //        }
        //        return _instance;
        //    }
        //}

        AudioSource _audioSource;
        float _backgroundMusicVolume = 0.45f;
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            if (_audioSource == null)
                Debug.LogWarning("SoundController.cs: AudioSource is not found");

            _audioSource.Stop();
            _audioSource.volume = _backgroundMusicVolume;
            _audioSource.Play();

            //DontDestroyOnLoad(this.gameObject);

        }



     }

