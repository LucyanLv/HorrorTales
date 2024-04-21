using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarMuerta : MonoBehaviour
{
    [SerializeField] GameObject muerta;
    private void Start()
    {
        muerta.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            muerta.SetActive(true);
        }
    }
}
