using FMODUnity;
using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTV : MonoBehaviour
{
    [SerializeField] GameObject sonidoCarne;
    [SerializeField] GameObject sonidoNoticia;
    [SerializeField] GameObject estatica;
    [SerializeField] GameObject colliderAnimacion;

    bool estadoNoticia;
    bool clicProcesado; // Bandera para evitar múltiples clics en el mismo frame

    private void Start()
    {
        NoticiaApagada();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Acá Entré al collider");
        if (other.CompareTag("Player") && Input.GetMouseButtonUp(0) && !clicProcesado)
        {
            clicProcesado = true; // Marcar el clic como procesado

            if (estadoNoticia == false)
            {
                NoticiaPrendida();
            }
            else
            {
                NoticiaApagada();
            }
        }
    }

    private void LateUpdate()
    {
        clicProcesado = false; // Restablecer la bandera al final del frame
    }

    public void NoticiaPrendida()
    {
        estadoNoticia = true;
        sonidoCarne.SetActive(false);
        sonidoNoticia.SetActive(true);
        estatica.SetActive(true);

        colliderAnimacion.SetActive(true);
        StartCoroutine(ApagaColliderAnimacion());
    }

    IEnumerator ApagaColliderAnimacion()
    {
        yield return new WaitForSeconds(5f);
        colliderAnimacion.SetActive(false);
    }

    public void NoticiaApagada()
    {
        estadoNoticia = false;
        sonidoCarne.SetActive(true);
        sonidoNoticia.SetActive(false);
        estatica.SetActive(false);
    }
}
