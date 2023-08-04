using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class CinematicController : MonoBehaviour
{
    PlayableDirector director;
    [SerializeField] CinematicsSettings settings;

    int currentCinematicIndex;

    private void OnEnable()
    {
        DelegatesHelper.playCinematic += PlayCinematic;
        director.stopped += CinematicFinished;
    }
    private void OnDisable()
    {
        DelegatesHelper.playCinematic -= PlayCinematic;
        director.stopped -= CinematicFinished;
    }
    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }

    public void PlayCinematic(int index)
    {
        currentCinematicIndex = index;
        director.playableAsset = settings.Cinematics[currentCinematicIndex].Cinematic;
        director.Play();
    }

    public void CinematicFinished(PlayableDirector director)
    {
        DelegatesHelper.cinematicFinished.Invoke(currentCinematicIndex);
        Debug.Log("Aqui se llama al controlador de puertas y se activan segun ids");
    }
}
