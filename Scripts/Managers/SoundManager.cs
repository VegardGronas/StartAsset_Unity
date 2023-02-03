using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    [Header("Settings")]
    [SerializeField] private SoundSettings _soundSettings;

    private float _threshold = 80f;

    private float _masterVolume;
    public float MasterVolume { get { return _masterVolume; } set { _masterVolume = SetVolume(_soundSettings.masterVolParameter,value); } }

    private float _musicVolume;
    public float MusicVolume { get {return _musicVolume; } set { _musicVolume = SetVolume(_soundSettings.musicVolParameter, value); } }

    private float _effectsVolume;
    public float EffectsVolume { get { return _effectsVolume; } set { _effectsVolume = SetVolume(_soundSettings.effectsVolParameter, value); } }

    private float _ambienceVolume;
    public float AmbienceVolume { get { return _ambienceVolume; } set { _ambienceVolume = SetVolume(_soundSettings.ambientVolParameter, value); } }

    private void Start()
    {
        MasterVolume = GetVolume(_soundSettings.masterVolParameter);
        MusicVolume = GetVolume(_soundSettings.musicVolParameter);
        EffectsVolume = GetVolume(_soundSettings.effectsVolParameter);
        AmbienceVolume = GetVolume(_soundSettings.ambientVolParameter);
    }

    private float GetVolume(string parameter)
    {
        _soundSettings.mixer.GetFloat(parameter, out float value);
        return value;
    }

    private float SetVolume(string parameter, float inputValue)
    {
        float value = _soundSettings.volumeCurve.Evaluate(inputValue);
        _soundSettings.mixer.SetFloat(parameter, value * _threshold);
        return value;
    }
}