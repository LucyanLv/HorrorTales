using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] PlayableAsset _animation;
   [SerializeField] PlayableDirector _director;
   [SerializeField] GameObject _obj;
   private void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Player"))
    {
         _director.playableAsset=_animation;
        _director.Play();
    }     
   }

   private void Start() {
    Cursor.lockState= CursorLockMode.Locked;
   }

   private void Update() {
        RaycastHit hit;
        Vector3 _newPosition=new Vector3(Screen.width/2,Screen.height/2,Camera.main.transform.position.z);
       Physics.Raycast(Camera.main.ScreenPointToRay(_newPosition),out hit);
        //Debug.Log(hit.collider.gameObject.name);
        if(hit.collider)
        {
            if (hit.collider.GetComponent<PuzzlePart>())
            {
                Debug.Log(hit.collider.gameObject);
                _obj.SetActive(hit.collider.GetComponent<PuzzlePart>()?true:false);
            }
           
        }
   }
}
