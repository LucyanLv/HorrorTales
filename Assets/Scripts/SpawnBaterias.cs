using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBaterias : MonoBehaviour
{
    [SerializeField] GameObject[] baterias;
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

        pointsBateryinRoom[rooms[0]] = new Vector3[] { new Vector3(389.119995f, 20, -143.679993f), new Vector3(389.119995f, 20, -82.5599976f), new Vector3(344.959991f, 20, -106.879997f) };
        pointsBateryinRoom[rooms[1]] = new Vector3[] { new Vector3(195.519989f, 20, -129.440002f), new Vector3(216f, 20, 17.7600002f), new Vector3(196, 20, 104.799995f) };
        pointsBateryinRoom[rooms[2]] = new Vector3[] { new Vector3(-50.8799973f, 20, 40.7999992f), new Vector3(128.319992f, 20, 82.2399979f), new Vector3(46.5599976f, 20, 147.199997f) };
        pointsBateryinRoom[rooms[3]] = new Vector3[] { new Vector3(30.5599976f, 20, -14.8800001f) };
        pointsBateryinRoom[rooms[4]] = new Vector3[] { new Vector3(17.9200001f, 20, -127.68f) };
        pointsBateryinRoom[rooms[5]] = new Vector3[] { new Vector3(-136.319992f, 20, -127.68f), new Vector3(-136.319992f, 20, 90.0799942f) };
        pointsBateryinRoom[rooms[6]] = new Vector3[] { new Vector3(-293.759979f, 20, -22.7200012f) };
        pointsBateryinRoom[rooms[7]] = new Vector3[] { new Vector3(-204.639999f, 20, 31.3599987f), new Vector3(-328.639984f, 20, 152.160004f) };
        pointsBateryinRoom[rooms[8]] = new Vector3[] { new Vector3(-252.479996f, 20, -108.479996f) };
    }

    private void Update()
    {

    }


    public void RespawnBateria(Vector3 position)
    {
        GameObject[] vecinos = ObtenerVecinos(position);
        for (int i = 0; i < vecinos.Length; i++)
        {
            baterias[i].transform.position = ObtenerPosicionEnVecino(vecinos[i]);
        }
    }

    private Vector3 ObtenerPosicionEnVecino(GameObject vecino)
    {
       
        int indiceAleatorio = Random.Range(0, pointsBateryinRoom[vecino].Length);
        Debug.Log(vecino.name);
        Vector3 nuevoPunto = pointsBateryinRoom[vecino][indiceAleatorio];

        Debug.Log(nuevoPunto);
        return nuevoPunto;

    }
 
    private GameObject ObtenerHabitacionActual(Vector3 position)
    {

        Vector3 tamanioCaja = new Vector3(0.5f, 1.0f, 0.5f);

        Collider[] colliders = Physics.OverlapBox(position, tamanioCaja * 0.5f, Quaternion.identity, capasHabitacion);

        if (colliders.Length > 0)
        {
            foreach (Collider collider in colliders)
            {
                Debug.Log("El personaje esta en la habitacion: " + collider.gameObject.name);
                return collider.gameObject;
            }
        }
        else
        {
            Debug.Log("El personaje no esta en ninguna habitacion.");
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

    private GameObject[] ObtenerVecinos(Vector3 position)
    {
        return neigthborgRooms[ObtenerHabitacionActual(position)];
    }


}
