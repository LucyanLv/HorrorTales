using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarMuerta : MonoBehaviour
{
    GameObject muerta;
    void Start()
    {
        muerta.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            muerta.SetActive(false);
        }
    }
}
