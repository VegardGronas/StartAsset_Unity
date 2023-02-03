using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SoundSettings : MonoBehaviour
{
    [SerializeField] private SoundParameters soundParameter;

    public void InputVolumeValue(System.Single value)
    {
        switch(soundParameter)
        {
            case SoundParameters.Master:
                    SoundManager.Instance.MasterVolume = value;
                break;
            case SoundParameters.Ambience:
                    SoundManager.Instance.AmbienceVolume = value;
                break;
            case SoundParameters.Effects:
                    SoundManager.Instance.EffectsVolume = value;
                break;
            case SoundParameters.Music:
                    SoundManager.Instance.MusicVolume = value;
                break;
        }
    }
}
