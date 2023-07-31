using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowAudio : MonoBehaviour
{
    FMOD.Studio.EventInstance sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = FMODUnity.RuntimeManager.CreateInstance("event:/House/BrokenWindow");
    }

    // Update is called once per frame
    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(sound, GetComponent<Transform>(), GetComponent<Rigidbody>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sound.start();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
