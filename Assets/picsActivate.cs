using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class picsActivate : MonoBehaviour
{
    [SerializeField] GameObject fotos;
    [SerializeField] GameObject cuadroFoto;
    // Start is called before the first frame update

    private void Start()
    {
        fotos.SetActive(false);
        cuadroFoto.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fotos.SetActive(true);
            cuadroFoto.SetActive(true);
        }
    }
}
