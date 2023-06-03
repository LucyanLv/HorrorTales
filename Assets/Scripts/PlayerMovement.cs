using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables publicas para controlar la velocidad de movimiento y la sensibilidad del raton
    [Header("Velocidad Mouse")]
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float mouseSensitivity = 50f;

    [SerializeField] Transform orientation;

    [SerializeField] Camera camera;



    // Variables privadas para controlar la rotacion vertical del jugador y la velocidad de movimiento actual
    private float verticalRotation = 0f;
    private float currentMoveSpeed = 0f;

    // Variables privadas para controlar el movimiento de los pasos
    private float stepDistance = 1.5f;
    private float stepTimer = 0f;
    private bool isStepping = false;

    // Variables privadas para controlar el audio del movimiento de los pasos
    [Header ("Audio Pasos")]
    private AudioSource audioSource;
    public AudioClip[] footstepSounds;

    void Start()
    {
        // Establece la velocidad de movimiento actual en la velocidad de movimiento inicial
        currentMoveSpeed = moveSpeed;

        // Obtiene el componente de AudioSource
        audioSource = GetComponent<AudioSource>();
    }

    // M�todo Update que se ejecuta cada frame del juego
    void Update()
    {
        // Control de movimiento
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector3 movement = orientation.right * horizontalMovement + orientation.forward * verticalMovement;
        movement.Normalize();
        transform.position += movement * currentMoveSpeed * Time.deltaTime;

        // Control de rotaci�n horizontal
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up, horizontalRotation);

        // Control de rotaci�n vertical
        float verticalMovementRotation = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        verticalRotation -= verticalMovementRotation;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        camera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
     

        // Control de velocidad de movimiento
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentMoveSpeed = moveSpeed * 1.3f;
        }
        else
        {
            currentMoveSpeed = moveSpeed;
        }

        // Control de movimiento de los pasos
        if (movement.magnitude > 0 && !isStepping)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer > stepDistance / currentMoveSpeed)
            {
                isStepping = true;
                stepTimer = 0f;

                // Reproduce un sonido de movimiento de los pasos al azar
//                audioSource.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)]);
            }
        }
        else if (isStepping)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer > 0.2f)
            {
                isStepping = false;
                stepTimer = 0f;
            }
        }
    }


//     [SerializeField]
//     private GameObject player, referencia;
//     private Vector3 distancia;
// 	// Use this for initialization
// 	void Start () {
//         distancia = transform.position - player.transform.position;
// 	}
	
// 	// Update is called once per frame
// 	void LateUpdate () {
//         distancia = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*2,Vector3.up)*distancia;

//         transform.position = player.transform.position + distancia;
//         transform.LookAt(player.transform.position);

//         Vector3 copRot = new Vector3(0,transform.eulerAngles.y,0);
//         referencia.transform.eulerAngles = copRot;
// 	}
// }

}
