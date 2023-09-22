using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CinematicController : MonoBehaviour
{
    PlayableDirector director;
    [SerializeField] Dictionary<int, List<int>> doorsIds = new Dictionary<int, List<int>>();
    [SerializeField] List<PlayableAsset> cinematics = new List<PlayableAsset>();
    [SerializeField] GameObject[] aims;
    [SerializeField] Door[] doors;
    [SerializeField] GameObject player;
    [SerializeField] GameObject col3;


    int currentCinematicIndex;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        //settings.SaveToFile();
        //settings.LoadDataFromFile();
        doorsIds.Add(0, new List<int>());
        doorsIds.Add(1, new List<int> { 0, 3 });
        doorsIds.Add(2, new List<int> { 1 });
        doorsIds.Add(3, new List<int> { 2, 7 });
        doorsIds.Add(4, new List<int> { 6 });
        doorsIds.Add(5, new List<int>());
        doorsIds.Add(6, new List<int> { 4, 5 });
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
        director.playableAsset = cinematics[currentCinematicIndex];
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
        DelegatesHelper.cinematicFinished.Invoke(currentCinematicIndex);
        aims[currentCinematicIndex].SetActive(false);
        MakeAditionalActions();
    }

    public void MakeAditionalActions()
    {
        player.SetActive(true);
        UnlockDoors(doorsIds[currentCinematicIndex]);
        switch (currentCinematicIndex)
        {
            case 2:
                player.transform.position = new Vector3(377.840332f, 9.91821289e-05f, -81.5740738f);
                PlayCinematic(0);
                col3.SetActive(true);
                break;
            case 5:
                GameObject a = aims[0];
                a.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Debug.Log("aca se va a la chingada y ya acabo el juego uwu");
                SceneManager.LoadScene(0);
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
