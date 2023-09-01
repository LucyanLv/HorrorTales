using FMODUnity;
using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlTV : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference sonidoCarne;
    [SerializeField] FMODUnity.EventReference noticiaTV;

    private FMOD.Studio.EventInstance sonidoCarneInstance;
    private FMOD.Studio.EventInstance noticiaTVInstance;

    [SerializeField] bool meatSound;
    [SerializeField] bool notice;

 
    private void Start()
    {
        meatSound = true;
        notice = false;
    }
    private void Update()
    {
        if (meatSound == true)
        {
            //sonidoCarne.SetActive(true);
            sonidoCarneInstance.start();
        }
        if (meatSound == false)
        {
            sonidoCarneInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            //sonidoCarne.SetActive(false);
        }

        if (notice == true)
        {
            noticiaTVInstance.start();
        //    noticiaTV.SetActive(true);
        }
        if (notice == false)
        {
            noticiaTVInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            //   noticiaTV.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            meatSound = false;
            Debug.Log("Si funciona esta parte del sonido");

        }
    }

    private void OnDestroy()
    {
        noticiaTVInstance.release();
        sonidoCarneInstance.release();
    }
}
