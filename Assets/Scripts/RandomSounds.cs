using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class RandomSounds : MonoBehaviour
{
    // Referencia al evento de FMOD
    FMODUnity.EventReference randomSounds;
    public string fmodEventPath;

    // Parámetro discreto para seleccionar el sonido
    public string parameterName = "sonidosRandom";

    // Tiempo mínimo y máximo de espera antes de reproducir el sonido
    public float minWaitTime = 5f;
    public float maxWaitTime = 10f;

    private FMOD.Studio.EventInstance soundEvent;

    private void Start()
    {
        // Inicializar el evento de FMOD
        soundEvent = FMODUnity.RuntimeManager.CreateInstance(fmodEventPath);
    }

    private void OnEnable()
    {
        // Comenzar la rutina para reproducir sonidos aleatorios
        StartCoroutine(PlayRandomSoundWithDelay());
    }

    private void OnDisable()
    {
        // Detener el evento de FMOD cuando el objeto se desactive
        soundEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    private IEnumerator PlayRandomSoundWithDelay()
    {
        while (true)
        {
            // Generar un tiempo de espera aleatorio
            float randomWaitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(randomWaitTime);

            // Seleccionar un valor aleatorio para el parámetro discreto
            int randomParameterValue = Random.Range(0, 12);

            // Setear el valor del parámetro discreto en FMOD
            soundEvent.setParameterByName("sonidosRandom", randomParameterValue);

            // Reproducir el sonido
            soundEvent.start();
        }
    }
}
