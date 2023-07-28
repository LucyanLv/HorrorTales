using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] PlayableAsset _animation;
    [SerializeField] PlayableDirector _director;
    [SerializeField] GameObject _obj;
    [SerializeField] private bool wasPlayed = false;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && !wasPlayed)
        {
            Debug.Log("entro player en " + name + "");
            _director.playableAsset = _animation;
            _director.Play();
            _obj.GetComponent<Door>().UnlockDoor();
            wasPlayed = true;
        }
    }

    
}
