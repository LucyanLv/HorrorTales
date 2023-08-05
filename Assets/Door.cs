using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator controller;
    [SerializeField] private bool doorOpened = false;
    [SerializeField] private float maxInteractDistance = 3f;

    private void Start()
    {
        controller = transform.Find("Puerta_LowPoly_009").GetComponent<Animator>();
    }

    private void Update()
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
        }
    }

    private bool CanInteractWithDoor()
    {
        // Check if the player is tagged as "Player" and within the interactable distance
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
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
}
