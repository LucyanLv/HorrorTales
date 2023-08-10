using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator controller;
    [SerializeField] private int id;
    [SerializeField] private bool doorOpened = false;
    [SerializeField] private bool doorLocked = true;
    [SerializeField] private float maxInteractDistance = 3f;
    public int Id { get => id; set => id = value; }

    private void Start()
    {
        controller = transform.GetComponentInChildren<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the player is close enough and facing the door before allowing interaction
            if (CanInteractWithDoor())
            {
                doorOpened = !doorOpened;
                controller.SetBool("Opened", doorOpened);
                controller.SetBool("Closed", !doorOpened);
                FMODUnity.RuntimeManager.PlayOneShot("event:/House/UnlookDoor");
                if (doorOpened)
                {
                    StartCoroutine(OpenDoorCoroutine());
                }
            }
            else
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/House/UnlookDoor");
            }
        }

    }

    private bool CanInteractWithDoor()
    {
        // Check if the player is tagged as "Player" and within the interactable distance
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && !doorLocked)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            return distanceToPlayer <= maxInteractDistance;
        }
        return false;
    }

    IEnumerator OpenDoorCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        FMODUnity.RuntimeManager.PlayOneShot("event:/House/OpeningDoor");
    }

    public void unlockDoor()
    {
        doorLocked = false;
        FMODUnity.RuntimeManager.PlayOneShot("event:/House/UnlookDoor");

    }
}
