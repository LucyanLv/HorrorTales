using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;

[Serializable]
public class CinematicProperty
{
    [SerializeField] PlayableAsset cinematic;
    [SerializeField] List<int> doors = new List<int>();


    public PlayableAsset Cinematic { get => cinematic; set => cinematic = value; }
    public List<int> Doors { get => doors; set => doors = value; }
}

[CreateAssetMenu(fileName = "Scriptable_CinematicSettings", menuName = "Cinematic settings")]
public class CinematicsSettings : ScriptableObject
{
    [SerializeField] List<CinematicProperty> cinematics = new List<CinematicProperty>();

    public List<CinematicProperty> Cinematics { get => cinematics; set => cinematics = value; }

    private const string FILENAME = "cinematics.dat";

    [ContextMenu("Save")]
    public void SaveToFile()
    {
        var filePath = Path.Combine(Application.persistentDataPath, FILENAME);

        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }

        var json = JsonUtility.ToJson(this);
        File.WriteAllText(filePath, json);
    }


    public void LoadDataFromFile()
    {
        var filePath = Path.Combine(Application.persistentDataPath, FILENAME);

        if (!File.Exists(filePath))
        {
            Debug.LogWarning($"File \"{filePath}\" not found!", this);
            return;
        }

        var json = File.ReadAllText(filePath);
        JsonUtility.FromJsonOverwrite(json, this);
    }
}

