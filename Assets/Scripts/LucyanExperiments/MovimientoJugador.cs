using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public AudioClip[] footstepSounds;
    public Animator animator;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Obtener la entrada del teclado para el movimiento
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Obtener la velocidad de movimiento según la tecla SHIFT
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        // Calcular la dirección de movimiento en base a la cámara
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0f;
        movement.Normalize();

        // Obtener la rotación de la cámara
        float cameraRotationY = Camera.main.transform.eulerAngles.y;

        // Girar el personaje hacia la dirección de la cámara
        Quaternion newRotation = Quaternion.Euler(0f, cameraRotationY, 0f);
        transform.rotation = newRotation;

        // Mover al jugador
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Reproducir sonido de pasos
        if (movement.magnitude > 0f && !audioSource.isPlaying)
        {
            PlayFootstepSound();
        }

        // Configurar la animación de caminar
        animator.SetFloat("Speed", movement.magnitude);
    }

    void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, footstepSounds.Length);
            audioSource.clip = footstepSounds[randomIndex];
            audioSource.Play();
        }
    }
}

