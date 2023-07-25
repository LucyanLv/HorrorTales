using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator controller;
    [SerializeField] private bool canBeOpened = false;
    [SerializeField] private bool doorOpened = false;

    private void Start()
    {
        controller = transform.Find("Puerta_LowPoly_009").GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Ya toy en la puerta xD");

        if (other.CompareTag("Player"))
        {

            if (Input.GetMouseButtonDown(0))
            {
                doorOpened = !doorOpened;
                controller.SetBool("Opened", doorOpened);
                controller.SetBool("Closed", !doorOpened);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if (other.CompareTag("Player"))
        // {
        //     controller.SetBool("Closed", true);
        //     controller.SetBool("Opened", false);
        // }

    }
}
