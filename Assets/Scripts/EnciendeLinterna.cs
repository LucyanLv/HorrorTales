using FMODUnity;
using FMOD.Studio;
using UnityEngine;

public class EnciendeLinterna : MonoBehaviour
{
    GameObject lightPlayer;

    private void Start()
    {
        lightPlayer = GameObject.FindWithTag("Linterna");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Character/Linterna_Prende");
            lightPlayer.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Character/Linterna_Apaga");
            lightPlayer.SetActive(true);
        }
    }
}
