using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicActivator : MonoBehaviour
{
    [SerializeField] int cinematicIndex;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DelegatesHelper.playCinematic.Invoke(cinematicIndex);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void CinematicFinished(int index)
    {
        if (cinematicIndex == index)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        DelegatesHelper.cinematicFinished += CinematicFinished;
    }

    private void OnDisable()
    {
        DelegatesHelper.cinematicFinished -= CinematicFinished;
        
    }
}
