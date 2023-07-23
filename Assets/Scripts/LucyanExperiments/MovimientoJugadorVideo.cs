using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovimientoJugadorVideo : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public float movementSpeed;

    //Animación
    Animator animator;
    bool isMoving;
    bool idle;

    public Vector2 sensitivity;

    [SerializeField] new Transform camera;


    // Start is called before the first frame update
    void Start()
    {
    rigidbody = GetComponent<Rigidbody>();    
        animator = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
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


        if (horizontal != 0 || vertical != 0)
        {
            isMoving = true;
            idle = false;

            Vector3 direction = (transform.forward * vertical + transform.right * horizontal).normalized;
            rigidbody.velocity = direction * movementSpeed;

            animator.SetBool("Moving", isMoving);
            animator.SetBool("Idle", idle);

        }
        else if (horizontal == 0 && vertical == 0)
        {
            idle = true;
            isMoving = false;

            rigidbody.velocity = Vector3.zero;
            animator.SetBool("Idle", idle);

        }
    }

    void MouseControl()
    {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        if ( horizontal != 0)
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
}
