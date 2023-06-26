using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator controller;

    private void Start()
    {
        controller = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Ya toy en la puerta xD");

        if (other.CompareTag("Player"))
        {
            
            if(Input.GetMouseButtonDown(0))
            {
                controller.SetBool("Opened", true);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            controller.SetBool("Closed", true);
            controller.SetBool("Opened", false);
        }

    }
}
