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

