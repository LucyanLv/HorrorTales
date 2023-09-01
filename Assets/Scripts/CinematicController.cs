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
        string anim = $"Animation_0{currentCinematicIndex}";
        Debug.Log($" se supone dara play a {director.playableAsset.name}  y la anim {anim}");
        GameObject a = GameObject.Find(anim);
        if (a == null)
        {
            Debug.Log("nnooooooooooo");
        }
        a.GetComponent<PlayableDirector>().Play();
    }

    public void CinematicFinished(PlayableDirector director)
    {

        DelegatesHelper.cinematicFinished.Invoke(currentCinematicIndex);
        transform.Find($"Animation_0{currentCinematicIndex}").gameObject.SetActive(false);
        Debug.Log("Aqui se llama al controlador de puertas y se activan segun ids");
    }
}
