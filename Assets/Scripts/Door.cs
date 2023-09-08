using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator controller;
    [SerializeField] private int id;
    [SerializeField] private bool doorOpened = false;
    [SerializeField] private bool doorLocked;
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
            if (CanInteractWithDoor(other.gameObject))
            {
                doorOpened = !doorOpened;

                FMODUnity.RuntimeManager.PlayOneShot("event:/House/UnlookDoor");
                if (doorOpened)
                {
                    StartCoroutine(OpenDoorCoroutine());
                }                
                controller.SetBool("Opened", doorOpened);
            }
            else
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/House/UnlookDoor");
            }
        }

    }

    private bool CanInteractWithDoor(GameObject obj)
    {

        if (obj.CompareTag("Player") && !doorLocked)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, obj.transform.position);
            return distanceToPlayer <= maxInteractDistance;
        }
        return false;
    }

    IEnumerator OpenDoorCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        FMODUnity.RuntimeManager.PlayOneShot("event:/House/OpeningDoor");
    }

    public void UnlockDoor()
    {
        doorLocked = false;
        doorOpened = false;
        controller.SetBool("Opened", doorOpened);
        Debug.Log($" aca desbloquea la puerta {Id} del pivote {gameObject.name}");
        FMODUnity.RuntimeManager.PlayOneShot("event:/House/UnlookDoor");

    }
}
