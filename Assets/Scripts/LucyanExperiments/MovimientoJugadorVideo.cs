using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugadorVideo : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public float movementSpeed;

    //Animación
    Animator animator;
    bool isMoving;
    bool idle;


    // Start is called before the first frame update
    void Start()
    {
    rigidbody = GetComponent<Rigidbody>();    
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        movement();
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

    void MouseControll()
    {
        
    }
}
