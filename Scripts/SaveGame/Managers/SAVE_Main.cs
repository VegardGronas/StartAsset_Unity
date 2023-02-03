using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SAVE_Main
{
    public static bool SaveTransform(int constantID, Transform transform)
    {
        DATA_Transform data_transform = new DATA_Transform();
        data_transform.constantID = constantID;
        data_transform.location= transform.position;
        data_transform.rotation= transform.rotation;
        data_transform.scale= transform.localScale;

        string json = JsonUtility.ToJson(data_transform);
        string path = ReturnPath("transform") + ".json";
        File.WriteAllText(path, json);

        if (json != "") return true;
        else return false;
    }

    private static string ReturnPath(string targetDestination)
    {
        string path = Application.persistentDataPath + "/" + targetDestination;
        return path;
    }
}


public class DATA_Transform
{
    public int constantID;
    public Vector3 location;
    public Quaternion rotation;
    public Vector3 scale;
}