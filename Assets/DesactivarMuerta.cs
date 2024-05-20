using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarMuerta : MonoBehaviour
{
    public GameObject muerta;
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            muerta.SetActive(false);
        }
    }
}
