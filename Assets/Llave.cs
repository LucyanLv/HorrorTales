using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindWithTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
