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
    int contador = 0;

    private void Start()
    {
        NoticiaApagada();
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Acá Entré al collider");
        if (other.gameObject.CompareTag("Player") && Input.GetMouseButtonUp(0) && estadoNoticia == false)
        {
            NoticiaPrendida();
            contador++;
            //Debug.Log("Acá debería prenderse la noticia");
        }

        else if (other.gameObject.CompareTag("Player") && Input.GetMouseButtonUp(0) && estadoNoticia == true)
        {
            NoticiaApagada();
            //Debug.Log("Acá debería apagarse la noticia");
        }
    }

    public void NoticiaPrendida()
    {
        estadoNoticia = true;
        sonidoCarne.SetActive(false);
        sonidoNoticia.SetActive(true);
        estatica.SetActive(true);
        if (contador <= 0)
        {

            colliderAnimacion.SetActive(true);
            StartCoroutine(aja());
        }
    }

    IEnumerator aja()
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