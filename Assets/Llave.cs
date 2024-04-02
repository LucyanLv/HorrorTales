using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (GameObject.FindWithTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
