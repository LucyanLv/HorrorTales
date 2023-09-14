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
    private bool linternaEncendida = false;

    [Header("Linterna")]
    [SerializeField] private float linternaAgotadaEn = 60.0f;
    private float nivelBateria = 100.0f;
    public Slider batterySlider;

    [Header("RecargaBatería")]
    public float maximoNivelBateria = 100.0f;


    [Header("Cordura")]
    [SerializeField] private Slider corduraSlider;
    [SerializeField] private float tasaAumentoCordura = 10.0f;
    [SerializeField] private float tasaDescensoCordura = 5.0f;
    private float nivelCordura = 0.0f;

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

        if (nivelCordura <= 75.0f)
        {
            Debug.Log("Locura al 75");
            fearLevel1.SetActive(true);
            //GameObject.FindObjectOfType<Chase>().AddActivationProbability(0.15f);
            foreach (Chase item in GameObject.FindObjectsOfType<Chase>())
            {
                item.AddActivationProbability(15);
            }

            if (nivelCordura <= 50.0f)
            {
                Debug.Log("Locura en 50");
                fearLevel2.SetActive(true);
                // GameObject.FindObjectOfType<Chase>().AddActivationProbability(0.15f);
                if (nivelCordura <= 50.0f)
                {
                    // Reproducir el sonido de latidos del corazón en un loop
                    if (!heartSoundEvent.isValid())
                    {
                        heartSoundEvent = FMODUnity.RuntimeManager.CreateInstance(heartSoundEventPath);
                        heartSoundEvent.start();
                    }
                }

                    foreach (Chase item in GameObject.FindObjectsOfType<Chase>())
                    {
                        item.AddActivationProbability(15);
                    }

                    if (nivelCordura <= 25.0f)
                    {
                        Debug.Log("Locura al 25");
                        fearLevel3.SetActive(true);
                        // GameObject.FindObjectOfType<Chase>().AddActivationProbability(0.20f);
                        foreach (Chase item in GameObject.FindObjectsOfType<Chase>())
                        {
                            item.AddActivationProbability(20);
                        }
                    }
                }
            }

            if (nivelCordura >= 25.0f)
            {
                Debug.Log("Locura recuperada al 25");
                fearLevel3.SetActive(false);
                //GameObject.FindObjectOfType<Chase>().MinusActivationProbability(0.20f);
                foreach (Chase item in GameObject.FindObjectsOfType<Chase>())
                {
                    item.MinusActivationProbability(20);
                }

                if (nivelCordura >= 50.0f)
                {
                    Debug.Log("Locura en 50");
                    fearLevel2.SetActive(false);
                    //GameObject.FindObjectOfType<Chase>().MinusActivationProbability(0.15f);
                    foreach (Chase item in GameObject.FindObjectsOfType<Chase>())
                    {
                        item.MinusActivationProbability(20);
                    }
                    if (nivelCordura >= 75)
                    {
                        Debug.Log("Locura recuperada al 75");
                        fearLevel1.SetActive(false);
                    //   GameObject.FindObjectOfType<Chase>().MinusActivationProbability(0.15f);
                    if (heartSoundEvent.isValid())
                    {
                        heartSoundEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                        heartSoundEvent.release();
                    }
                        foreach (Chase item in GameObject.FindObjectsOfType<Chase>())
                        {
                            item.MinusActivationProbability(20);
                        }
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
        else if (other.tag == "Bateria")
        {
            // Recargar la batería al 100%
            nivelBateria = maximoNivelBateria;
            ActualizarSliderBateria();
            // Puedes destruir el objeto de la batería si lo deseas
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
