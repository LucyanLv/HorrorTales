using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBaterias : MonoBehaviour
{
    [SerializeField] GameObject bateria;
    public LayerMask capasHabitacion;
    [SerializeField] public List<GameObject> rooms = new List<GameObject>();
    [SerializeField] public Dictionary<GameObject, GameObject[]> neigthborgRooms = new Dictionary<GameObject, GameObject[]>();

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
        BoxCollider boxCollider = ObtenerVecinoAleatorio(position).GetComponent<BoxCollider>();

        float randomX = Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
        float randomY = Random.Range(boxCollider.bounds.min.y + boxCollider.bounds.max.y / 5, boxCollider.bounds.max.y / 2);
        float randomZ = Random.Range(boxCollider.bounds.min.z, boxCollider.bounds.max.z);

        Vector3 puntoAleatorio = new Vector3(randomX, randomY, randomZ);

        //float radioVerificacion = 0.5f; // Ajusta según el tamaño de tu objeto (batería)

        /* while (true)
         {
             bool puntoLibre = true;

             Collider[] colliders = Physics.OverlapSphere(puntoAleatorio, radioVerificacion);

             foreach (var collider in colliders)
             {
                 // Si hay otro objeto en el punto aleatorio, no está libre
                 puntoLibre = false;
                 break;
             }

             if (puntoLibre) 
                 break;

             // Generar un nuevo punto aleatorio
             randomX = Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x);
             randomY = Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y/2);
             randomZ = Random.Range(boxCollider.bounds.min.z, boxCollider.bounds.max.z);

             puntoAleatorio = new Vector3(randomX, randomY, randomZ);
         }*/

        return puntoAleatorio;

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
