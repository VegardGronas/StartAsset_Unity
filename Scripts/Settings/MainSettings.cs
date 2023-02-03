using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainSettings", menuName = "Settings/Main")]
public class MainSettings : ScriptableObject
{
    public GameObject playerPrefab;
    public GameObject soundManager;
    public GameObject mainMenuUI;
}
