using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LinternaUsable : MonoBehaviour
{


    [Header("LinternaAccion")]
    [SerializeField] GameObject linterna;
    public bool linternaTomada = false;
    public bool linternaEncendida = false;
    [SerializeField] GameObject nuevaLinterna;

    [Header("Linterna")]
    [SerializeField] private float linternaAgotadaEn = 60.0f;
    public float nivelBateria = 10.0f; // Cambiar a p�blica
    public Slider batterySlider;

    [Header("RecargaBater�a")]
    public float maximoNivelBateria = 100.0f;


    [Header("Cordura")]
    [SerializeField] private Slider corduraSlider;
    [SerializeField] private float tasaAumentoCordura = 10.0f;
    [SerializeField] private float tasaDescensoCordura = 5.0f;
    public float nivelCordura = 0.0f; // Cambiar a p�blica
    public float valorProbabilidadControlado = 1;

    [Header("Fear")]
    [SerializeField] GameObject fearLevel1;
    [SerializeField] GameObject fearLevel2;
    [SerializeField] GameObject fearLevel3;

    [Header("FMOD")]
    FMODUnity.EventReference heartSound;
    public string heartSoundEventPath = "event:/Character/Heart";
    private FMOD.Studio.EventInstance heartSoundEvent;

    private void Start()
    {
        linterna.SetActive(false);
        ActualizarSliderBateria();

        // Iniciar el contador de cordura en 100%
        nivelCordura = 100.0f;
        ActualizarSliderCordura();
        heartSoundEvent = FMODUnity.RuntimeManager.CreateInstance(heartSoundEventPath);
        corduraSlider.onValueChanged.AddListener(ActualizarNivelCordura);

        nuevaLinterna.SetActive(false);
        valorProbabilidadControlado = 1;
    }
    public void ActualizarNivelCordura(float value)
    {
        float a = 100 - (nivelCordura/valorProbabilidadControlado); // Actualizar el valor de la variable basado en el Slider

        Debug.Log("Locura al actualizar nivel locura");
        fearLevel1.SetActive(a <= 75);
        fearLevel2.SetActive(a <= 50);
        fearLevel3.SetActive(a <= 25);
        //GameObject.FindObjectOfType<Chase>().AddActivationProbability(0.15f);
        foreach (Chase item in GameObject.FindObjectsOfType<Chase>())
        {
            item.AddActivationProbability(a);
        }
    }

    private void Update()
    {
        if (linternaTomada)
        {
            if (linternaEncendida)
            {
                nivelBateria -= Time.deltaTime / linternaAgotadaEn * 100.0f;
                if (nivelBateria <= 0)
                {
                    nivelBateria = 0;
                    apagarLinterna();
                }

                // Aumentar la cordura mientras la linterna est� encendida
                nivelCordura = Mathf.Min(100.0f, nivelCordura + Time.deltaTime * tasaAumentoCordura);

            }
            else
            {
                // Descender la cordura mientras la linterna est� apagada
                nivelCordura = Mathf.Max(0.0f, nivelCordura - Time.deltaTime * tasaDescensoCordura);
            }

            ActualizarSliderBateria();
            ActualizarSliderCordura();

            if (Input.GetMouseButtonDown(1))
            {
                linternaEncendida = !linternaEncendida;
                if (linternaEncendida)
                {
                    prenderLinterna();
                }
                else
                {
                    apagarLinterna();
                }
            }
        }

        if (nivelCordura <= 75.0f)
        {

            if (nivelCordura <= 50.0f)
            {

                if (nivelCordura <= 50.0f)
                {
                    if (!heartSoundEvent.isValid())
                    {
                        heartSoundEvent = FMODUnity.RuntimeManager.CreateInstance(heartSoundEventPath);
                        heartSoundEvent.start();
                    }
                }


                if (nivelCordura <= 25.0f)
                {
                    fearLevel3.SetActive(true);
                    // GameObject.FindObjectOfType<Chase>().AddActivationProbability(0.20f);

                }
            }
        }

        if (nivelCordura >= 25.0f)
        {
            fearLevel3.SetActive(false);
            //GameObject.FindObjectOfType<Chase>().MinusActivationProbability(0.20f);


            if (nivelCordura >= 50.0f)
            {
                fearLevel2.SetActive(false);
                //GameObject.FindObjectOfType<Chase>().MinusActivationProbability(0.15f);

                if (nivelCordura >= 75)
                {
                    fearLevel1.SetActive(false);
                    if (heartSoundEvent.isValid())
                    {
                        heartSoundEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                        heartSoundEvent.release();
                    }

                }
            }
        }

    }



    public void prenderLinterna()
    {
        linterna.SetActive(true);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Character/Linterna_Prende");
    }

    public void apagarLinterna()
    {
        linternaEncendida = false;
        linterna.SetActive(false);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Character/Linterna_Apaga");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ObjetoLinterna")
        {
            linternaTomada = true;
            Destroy(other.gameObject);
            nuevaLinterna.SetActive(true);
        }
        else if (other.tag == "Bateria")
        {
            // Recargar la bater�a al 100%
            nivelBateria = maximoNivelBateria;
            ActualizarSliderBateria();
            // Puedes destruir el objeto de la bater�a si lo deseas
            //Destroy(other.gameObject);
            Debug.Log($"aca vamos pal respawn {other.gameObject.name}");
        }
    }

    

    private void ActualizarSliderBateria()
    {
        if (batterySlider != null)
        {
            batterySlider.value = nivelBateria / 100.0f;
        }
    }

    private void ActualizarSliderCordura()
    {
        if (corduraSlider != null)
        {
            corduraSlider.value = nivelCordura / 100.0f;
        }
    }

}
