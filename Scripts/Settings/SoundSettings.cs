using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "SoundSettings", menuName = "Settings/SoundSettings")]
public class SoundSettings : ScriptableObject
{
    [Header("The mixer to use")]
    public AudioMixer mixer;
    [Header("Exposed parameters in mixer")]
    public string masterVolParameter;
    public string ambientVolParameter;
    public string musicVolParameter;
    public string effectsVolParameter;

    [Header("Smooth volume")]
    public AnimationCurve volumeCurve;
}
