using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBaterias : MonoBehaviour
{
    [SerializeField] GameObject bateria;
    public LayerMask capasHabitacion;
    [SerializeField] public List<GameObject> rooms = new List<GameObject>();
    [SerializeField] public Dictionary<GameObject, GameObject[]> neigthborgRooms = new Dictionary<GameObject, GameObject[]>();
    [SerializeField] public Dictionary<GameObject, Vector3[]> pointsBateryinRoom = new Dictionary<GameObject, Vector3[]>();

    private void Start()
    {
        neigthborgRooms[rooms[0]] = new GameObject[] { rooms[1] };
        neigthborgRooms[rooms[1]] = new GameObject[] { rooms[0], rooms[2] };
        neigthborgRooms[rooms[2]] = new GameObject[] { rooms[3], rooms[1] };
        neigthborgRooms[rooms[3]] = new GameObject[] { rooms[2], rooms[4] };
        neigthborgRooms[rooms[4]] = new GameObject[] { rooms[3] };
        neigthborgRooms[rooms[5]] = new GameObject[] { rooms[2], rooms[7] };
        neigthborgRooms[rooms[6]] = new GameObject[] { rooms[7], rooms[8] };
        neigthborgRooms[rooms[7]] = new GameObject[] { rooms[5], rooms[6] };
        neigthborgRooms[rooms[8]] = new GameObject[] { rooms[6] };

        pointsBateryinRoom[rooms[0]] = new Vector3[] { new Vector3(374.100006f, 126.841339f, -151.6669922f), new Vector3(402.200012f, 126.841339f, 88.2000008f), new Vector3(394.100006f, 126.841339f, -401.8999996f) };
        pointsBateryinRoom[rooms[1]] = new Vector3[] { new Vector3(101, 126.841339f, -18), new Vector3(124, 126.841339f, 101), new Vector3(85, 126.841339f, 194) };
        pointsBateryinRoom[rooms[2]] = new Vector3[] { new Vector3(14.6000004f, 126.841339f, 148.199997f), new Vector3(-46, 126.841339f, 209.699997f), new Vector3(-143.699997f, 126.841339f, 144.600006f) };
        pointsBateryinRoom[rooms[3]] = new Vector3[] { new Vector3(-169, 126.841339f, 76), new Vector3(-72, 126.841339f, 57), new Vector3(1, 126.841339f, 67) };
        pointsBateryinRoom[rooms[4]] = new Vector3[] { new Vector3(-72.5f, 126.841339f, -2.5999999f) };
        pointsBateryinRoom[rooms[5]] = new Vector3[] { new Vector3(-231, 126.841339f, 213), new Vector3(-233, 126.841339f, -26) };
        pointsBateryinRoom[rooms[6]] = new Vector3[] { new Vector3(-423, 126.841339f, 70) };
        pointsBateryinRoom[rooms[7]] = new Vector3[] { new Vector3(-476, 126.841339f, 235.600006f), new Vector3(-298.200012f, 126.841339f, 192.800003f) };
        pointsBateryinRoom[rooms[8]] = new Vector3[] { new Vector3(-350, 126.841339f, -12) };
    }

    private void Update()
    {

    }


    public void RespawnBateria(Vector3 position)
    {
        bateria.transform.position = ObtenerPosicionEnVecinoAleatorio(position);
    }

    private Vector3 ObtenerPosicionEnVecinoAleatorio(Vector3 position)
    {
        GameObject vecino = ObtenerVecinoAleatorio(position);
        int indiceAleatorio = Random.Range(0, pointsBateryinRoom[vecino].Length);
        Vector3 nuevoPunto = pointsBateryinRoom[vecino][indiceAleatorio];

        Debug.Log(nuevoPunto);
        return nuevoPunto;

    }

    private GameObject ObtenerHabitacionActual(Vector3 position)
    {

        // Dimensiones de la "caja" alrededor del punto para verificar colisión
        Vector3 tamañoCaja = new Vector3(0.5f, 1.0f, 0.5f); // Ajusta según tus necesidades

        // Verifica colisión en la posición del personaje usando una caja
        Collider[] colliders = Physics.OverlapBox(position, tamañoCaja * 0.5f, Quaternion.identity, capasHabitacion);

        if (colliders.Length > 0)
        {
            // El personaje está en una habitación (en el área de un BoxCollider)
            foreach (Collider collider in colliders)
            {
                // Accede a la información de la habitación (el collider)
                Debug.Log("El personaje está en la habitación: " + collider.gameObject.name);
                return collider.gameObject;
            }
        }
        else
        {
            Debug.Log("El personaje no está en ninguna habitación.");
        }
        return null;
    }

    private GameObject ObtenerVecinoAleatorio(Vector3 position)
    {
        int indiceAleatorio = Random.Range(0, neigthborgRooms[ObtenerHabitacionActual(position)].Length);
        GameObject habitacionVecina = neigthborgRooms[ObtenerHabitacionActual(position)][indiceAleatorio];

        Debug.Log("El vecino aleatorio fue " + habitacionVecina);
        return habitacionVecina;
    }


}
