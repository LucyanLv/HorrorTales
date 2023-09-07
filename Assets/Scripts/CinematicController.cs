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
    [SerializeField] GameObject col3;


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
            Debug.Log("No ewncontro los objetos de la animacion");
        }
        else
        {
            a.SetActive(true);
            director.Play();
        }
    }

    public void CinematicFinished(PlayableDirector director)
    {
        Debug.Log("entro al finish");
        DelegatesHelper.cinematicFinished.Invoke(currentCinematicIndex);
        aims[currentCinematicIndex].SetActive(false);
        MakeAditionalActions();
    }

    public void MakeAditionalActions()
    {
        player.SetActive(true);
        UnlockDoors(settings.Cinematics[currentCinematicIndex].Doors);
        switch (currentCinematicIndex)
        {
            case 2:
                player.transform.position = new Vector3(377.840332f, 9.91821289e-05f, -81.5740738f);
                PlayCinematic(0);
                col3.SetActive(true);
                break;
        }
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
