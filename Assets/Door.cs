using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator controller;
    [SerializeField] private bool isLocked = true;
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

            if (Input.GetMouseButtonDown(0) && !isLocked)
            {
                doorOpened = !doorOpened;
                controller.SetBool("Opened", doorOpened);
                controller.SetBool("Closed", !doorOpened);
                FMODUnity.RuntimeManager.PlayOneShot("event:/House/UnlookDoor");
                StartCoroutine(OpenDoorCourtine());
            }

        }

        IEnumerator OpenDoorCourtine()
        {
            yield return new WaitForSeconds(0.5f);
            FMODUnity.RuntimeManager.PlayOneShot("event:/House/OpeningDoor");
        }
    }

    public void UnlockDoor()
    {
        isLocked = false;
        Debug.Log("Soy una puerta y me han desbloqueado");
        // TODO play leiftmotive de desbloqueo de puerta
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
