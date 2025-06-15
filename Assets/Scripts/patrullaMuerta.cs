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

    public Transform[] wayPointsSectorA;
    public Transform[] wayPointsSectorB;
    public Transform[] wayPointsSectorC;
    public Transform[] wayPointsSectorD;

    private string currentSector;

    private Transform[] wayPoints;

    int wayPointsIndex;
    [SerializeField] int stoppingDistance;

    private LinternaUsable linterna;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        linterna = player.GetComponent<LinternaUsable>();

        currentSector = PlayerSectorManager.Instance.currentSector;
        UpdateWaypointsBySector(currentSector);

    }

    // Update is called once per frame
    void Update()
    {
        string playerSector = PlayerSectorManager.Instance.currentSector;

        if (playerSector != currentSector)
        {
            currentSector = playerSector;
            UpdateWaypointsBySector(currentSector);
        }

        if (playerNear && linterna.linternaEncendida)
        {
            bool luzPrendida = linterna.linternaEncendida;
            print("Jugador está cerca. ¿Linterna encendida? " + luzPrendida);

            float targetSpeed = luzPrendida ? speedChase * 1.5f : speedChase;
            nav.speed = Mathf.Lerp(nav.speed, targetSpeed, Time.deltaTime * 2f);

            nav.speed = luzPrendida ? speedChase * 1.5f : speedChase;
            nav.destination = player.transform.position;


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
        if (linterna.linternaEncendida)
        {
            if (other.gameObject.tag == "Player")
            {
                playerNear = true;
            }
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
        nav.stoppingDistance = stoppingDistance;

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

    private void UpdateWaypointsBySector(string sector)
    {
        switch (sector)
        {
            case "A":
                wayPoints = wayPointsSectorA;
                break;
            case "B":
                wayPoints = wayPointsSectorB;
                break;
            case "C":
                wayPoints = wayPointsSectorC;
                break;
            case "D":
                wayPoints = wayPointsSectorD;
                break;
            default:
                Debug.LogWarning("Sector no reconocido: " + sector);
                break;
        }
    }
}