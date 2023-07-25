using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnciendeLinterna : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "LigthChangers")
        {
            if (other.CompareTag("EnciendeLuz"))
            {
                GetComponent<ControladorLinterna>().Enciende();
            }
            else
            {
                GetComponent<ControladorLinterna>().Apaga();
            }
        }
    }
}
