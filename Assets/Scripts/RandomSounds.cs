using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    [SerializeField] int tiempoAleatorioAdicional;
    [SerializeField] List<string> rutaSonidos = new List<string>();
    [SerializeField] int tiempoEsperaSonido;
    [SerializeField] float tiempoTotal;
    [SerializeField] float tiempoActual;

    FMODUnity.EventReference sonidosAleatorios;

    // Start is called before the first frame update
    void Start()
    {
        tiempoTotal = Random.Range(2, 5);
        tiempoActual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempoActual < tiempoTotal)
        {
            tiempoActual += Time.deltaTime;
        }
        else
        {
            //AprendePa hahahahaha

            FMOD.Studio.EventInstance sonidoAleatorio = FMODUnity.RuntimeManager.CreateInstance(rutaSonidos[Random.Range(0, rutaSonidos.Count)]);
            sonidoAleatorio.start();
            sonidoAleatorio.release();
            tiempoTotal = Random.Range(15, 30);
            tiempoActual = 0;
        }
    }
}