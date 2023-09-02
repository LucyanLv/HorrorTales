using FMODUnity;
using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlTV : MonoBehaviour
{
    [SerializeField] GameObject sonidoCarne;
    [SerializeField] GameObject sonidoNoticia;
    [SerializeField] GameObject estatica;

    bool estadoNoticia;

    private void Start()
    {
        NoticiaApagada();
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Ac� Entr� al collider");
        if (other.gameObject.CompareTag("Player") && Input.GetMouseButtonUp(0) && estadoNoticia == false)
        {
            NoticiaPrendida();
            //Debug.Log("Ac� deber�a prenderse la noticia");
        }

        else if (other.gameObject.CompareTag("Player") && Input.GetMouseButtonUp(0) && estadoNoticia == true)
        {
            NoticiaApagada();
            //Debug.Log("Ac� deber�a apagarse la noticia");
        }
    }

    public void NoticiaPrendida()
    {
        estadoNoticia = true;
        sonidoCarne.SetActive(false);
        sonidoNoticia.SetActive(true);
        estatica.SetActive(true);
    }

    public void NoticiaApagada()
    {
        estadoNoticia = false;
        sonidoCarne.SetActive(true);
        sonidoNoticia.SetActive(false);
        estatica.SetActive(false);
    }
}
