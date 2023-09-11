using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinternaUsable : MonoBehaviour
{
    [Header("LinternaAccion")]
    [SerializeField] GameObject linterna;
    public bool linternaTomada = false;
    private bool linternaEncendida = false;

    [Header("Linterna")]
    [SerializeField] private float linternaAgotadaEn = 60.0f;
    private float nivelBateria = 100.0f;
    public Slider batterySlider;

    [Header("Cordura")]
    [SerializeField] private Slider corduraSlider;
    [SerializeField] private float tasaAumentoCordura = 10.0f; // Tasa de aumento de cordura por segundo
    [SerializeField] private float tasaDescensoCordura = 5.0f; // Tasa de descenso de cordura por segundo
    private float nivelCordura = 0.0f; // Valor inicial de la cordura


    private void Start()
    {
        linterna.SetActive(false);
        ActualizarSliderBateria();

        // Iniciar el contador de cordura en 100%
        nivelCordura = 100.0f;
        ActualizarSliderCordura();
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

                // Aumentar la cordura mientras la linterna esté encendida
                nivelCordura = Mathf.Min(100.0f, nivelCordura + Time.deltaTime * tasaAumentoCordura);
            }
            else
            {
                // Descender la cordura mientras la linterna esté apagada
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
    }


    private void prenderLinterna()
    {
        linterna.SetActive(true);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Character/Linterna_Prende");
    }

    private void apagarLinterna()
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
