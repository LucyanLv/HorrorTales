using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class CinematicController : MonoBehaviour
{
    PlayableDirector director;

    [SerializeField] CinematicsSettings settings;
    [SerializeField] GameObject[] aims;
    [SerializeField] Door[] doors;
    [SerializeField] GameObject player;


    int currentCinematicIndex;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
    }
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


    public void PlayCinematic(int index)
    {
        currentCinematicIndex = index;
        player.SetActive(false);
        director.playableAsset = settings.Cinematics[currentCinematicIndex].Cinematic;
        Debug.Log($" se supone dara play a {director.playableAsset.name} ");
        GameObject a = aims[currentCinematicIndex];
        if (a == null)
        {
            Debug.Log("nnooooooooooo");
        }
        else
        {
            a.SetActive(true);
            director.Play();
            Debug.Log("aca debio dar play");
        }
    }

    public void CinematicFinished(PlayableDirector director)
    {
        Debug.Log("entro al finish");
        DelegatesHelper.cinematicFinished.Invoke(currentCinematicIndex);
        aims[currentCinematicIndex].SetActive(false);
        Debug.Log("Aqui se llama al controlador de puertas y se activan segun ids");
        MakeAditionalActions();
    }

    public void MakeAditionalActions()
    {
        player.SetActive(true);
        UnlockDoors(settings.Cinematics[currentCinematicIndex].Doors);
        /*switch (currentCinematicIndex)
        {
            case 0:
                break;
            case 1:
  
                break;
        }*/
    }

    private void UnlockDoors(List<int> doorsIds)
    {
        foreach (Door item in doors)
        {
            if (doorsIds.Contains(item.Id))
            {
                item.UnlockDoor();
            }
        }
    }
}
