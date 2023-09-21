using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator controller;
    [SerializeField] private int id;
    public bool doorOpened = false;
    public bool doorLocked;
    [SerializeField] private float maxInteractDistance = 3f;
    [SerializeField] private float clickCooldown = 0.5f; // Tiempo de enfriamiento entre clics
    private int clickCount = 0;

    public int Id { get => id; set => id = value; }

    private void Start()
    {
        controller = transform.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // Restablecer el contador de clics después de un tiempo
        if (clickCount > 0)
        {
            clickCooldown -= Time.deltaTime;
            if (clickCooldown <= 0)
            {
                clickCount = 0;
                clickCooldown = 0.5f; // Restablecer el tiempo de enfriamiento
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetMouseButtonDown(0) && clickCount == 0)
        {
            if (doorLocked == true)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/House/LockedDoor");
            }
            // Check if the player is close enough and facing the door before allowing interaction
            if (CanInteractWithDoor(other.gameObject))
            {
                doorOpened = !doorOpened;

                FMODUnity.RuntimeManager.PlayOneShot("event:/House/DoorClosed");
                if (doorOpened)
                {
                    StartCoroutine(OpenDoorCoroutine());
                }
                controller.SetBool("Opened", doorOpened);

                // Incrementar el contador de clics y activar el tiempo de enfriamiento
                clickCount++;
            }
            else
            {
                
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
