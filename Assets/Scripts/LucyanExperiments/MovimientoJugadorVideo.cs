using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using FMOD.Studio;

public class MovimientoJugadorVideo : MonoBehaviour
{
    private new Rigidbody rigidbody;
    //private EventInstance footstepEvent;

    public float movementSpeed;

    //Animación
    Animator animator;
    bool isMoving;

    public Vector2 sensitivity;

    [SerializeField] new Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;

        // Inicializar el evento de pasos
        //footstepEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Character/Footsteps"); // "Footsteps" es el nombre del evento de pasos que creaste en FMOD Studio
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        movement();
        MouseControl();
    }

    void movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        animator.SetBool("Moving", isMoving);
        if (horizontal != 0 || vertical != 0)
        {
            isMoving = true;

            Vector3 direction = (transform.forward * vertical + transform.right * horizontal).normalized;
            rigidbody.velocity = direction * movementSpeed;



            // Cambiar el valor del parámetro de velocidad del evento de pasos
            float characterSpeed = Mathf.Abs(vertical) + Mathf.Abs(horizontal);
            //FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Speed", characterSpeed);

            // Iniciar el evento de pasos (solo si no se está reproduciendo ya)
            //PLAYBACK_STATE playbackState;
            //footstepEvent.getPlaybackState(out playbackState);
            //if (playbackState != PLAYBACK_STATE.PLAYING)
            //{
            //    footstepEvent.start();
            //}
        }
        else if (horizontal == 0 && vertical == 0)
        {
            isMoving = false;
            //animator.SetBool("Moving", isMoving);
            rigidbody.velocity = Vector3.zero;

            // Detener el evento de pasos
            //footstepEvent.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }

    void MouseControl()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        if (horizontal != 0)
        {
            transform.Rotate(0, horizontal * sensitivity.x, 0);
        }

        if (vertical != 0)
        {
            Vector3 rotation = camera.localEulerAngles;
            rotation.x = (rotation.x - vertical * sensitivity.y + 360) % 360;

            if (rotation.x > 80 && rotation.x < 180)
            {
                rotation.x = 80;
            }
            else if (rotation.x < 280 && rotation.x > 180)
            {
                rotation.x = 280;
            }

            camera.localEulerAngles = rotation;
        }
    }

    private void OnDestroy()
    {
        // Liberar la instancia del evento de pasos al salir del juego o destruir el objeto
        //footstepEvent.release();
    }
}