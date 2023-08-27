using FMODUnity;
using FMOD.Studio;
using UnityEngine;

public class EnciendeLinterna : MonoBehaviour
{
    [SerializeField] GameObject Linterna;
    private EventInstance linternaEventInstance;
    private PARAMETER_ID prendeApagaParameter;

    private void Start()
    {
        linternaEventInstance = RuntimeManager.CreateInstance("event:/Character/Linterna");
        linternaEventInstance.start();
        linternaEventInstance.getParameterByID("Prende0Apaga1", out prendeApagaParameter);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            prendeApagaParameter.setValue(0); // Establecer el valor del parámetro
            linternaEventInstance.start();
            Linterna.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            prendeApagaParameter.setValue(1); // Establecer el valor del parámetro
            linternaEventInstance.start();
            Linterna.SetActive(true);
        }
    }
}
