using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivarTexto : MonoBehaviour
{
    [SerializeField] GameObject text;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(text);   
    }

}
