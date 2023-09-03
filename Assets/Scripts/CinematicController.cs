using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class CinematicController : MonoBehaviour
{
    PlayableDirector director;
    [SerializeField] GameObject player;
    [SerializeField] GameObject[] anims;

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
        director = anims[0].GetComponent<PlayableDirector>();
    }

    public void PlayCinematic(int index)
    {
        currentCinematicIndex = index;
        player.SetActive(false);
        director = anims[currentCinematicIndex].GetComponent<PlayableDirector>();
        string anim = $"Animation {anims[currentCinematicIndex].name}";
        Debug.Log($" se supone dara play a {director.playableAsset.name}  y la anim {anim}");
        GameObject a = anims[currentCinematicIndex];
        if (a == null)
        {
            Debug.Log("nnooooooooooo");
        }
        else
        {
            a.SetActive(true);
            director.Play();
        }
    }

    public void CinematicFinished(PlayableDirector director)
    {

        DelegatesHelper.cinematicFinished.Invoke(currentCinematicIndex);
        anims[currentCinematicIndex].SetActive(false);
        Debug.Log("Aqui se llama al controlador de puertas y se activan segun ids");
        MakeAditionalActions();
    }

    public void MakeAditionalActions()
    {
        switch (currentCinematicIndex)
        {
            case 0:
                player.SetActive(true);
                break;
            case 1:
                player.SetActive(true);
                break;
        }
    }
}
