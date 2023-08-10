using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.UIElements;

[Serializable]
public class CinematicProperty
{
    [SerializeField] PlayableAsset cinematic;
    [SerializeField] List<int> doorIds = new List<int>();

    public PlayableAsset Cinematic { get => cinematic; set => cinematic = value; }
    public List<int> DoorIds { get => doorIds; set => doorIds = value; }
}

[CreateAssetMenu(fileName = "Scriptable_CinematicSettings", menuName = "Cinematic settings")]
public class CinematicsSettings : ScriptableObject
{
    [SerializeField] List<CinematicProperty> cinematics = new List<CinematicProperty>();

    public List<CinematicProperty> Cinematics { get => cinematics; set => cinematics = value; }
}
