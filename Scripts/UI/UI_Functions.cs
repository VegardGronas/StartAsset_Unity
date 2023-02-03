using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Functions : MonoBehaviour
{
    public void LoadLevel(string level)
    {
        GameManager.Instance.LoadAsyncScene(level);
    }
}