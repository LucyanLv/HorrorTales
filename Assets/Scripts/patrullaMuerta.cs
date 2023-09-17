using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrullaMuerta : MonoBehaviour
{
    GameObject player;
    private NavMeshAgent nav;
    [SerializeField] bool playerNear;
    [SerializeField] float speedChase;
    Animator anim;

    [SerializeField] float patrolSpeed;
    [SerializeField] float patrolTimer;
    [SerializeField] float patrolWaitingTime;
    public Transform[] wayPoints;
    int wayPointsIndex;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNear)
        {
            nav.destination = player.transform.position;
            nav.speed = speedChase;

            if (nav.velocity == Vector3.zero)
            {
                anim.SetBool("walk", false);
            }
            else
            {
                anim.SetBool("walk", true);
            }
        }

        Patrolling();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNear = false;
            anim.SetBool("walk", false);
        }
    }

    public void Patrolling()
    {
        nav.speed = patrolSpeed;
        nav.stoppingDistance = 1;

        if (nav.remainingDistance < nav.stoppingDistance)
        {
            patrolTimer += Time.deltaTime;

            if (patrolTimer > patrolWaitingTime)
            {
                wayPointsIndex = (wayPointsIndex + 1) % wayPoints.Length; // Avanza al siguiente punto de patrulla
                patrolTimer = 0;
            }

            nav.destination = wayPoints[wayPointsIndex].position;
        }
    }

}