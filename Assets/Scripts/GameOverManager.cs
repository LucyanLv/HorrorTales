using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public float distanciaMaximaPermitida = 10.0f; // Variable para modificar desde el Inspector

    // Usa OnTriggerStay en lugar de OnCollisionEnter para verificar la distancia mientras el jugador está dentro del collider del enemigo
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemigo"))
        {
            // Obtén una referencia al jugador
            GameObject jugador = this.gameObject;

            // Verifica la distancia entre el jugador y el enemigo
            float distancia = Vector3.Distance(jugador.transform.position, other.transform.position);

            // Verifica si la distancia es menor o igual a la distancia máxima permitida y las condiciones de GameOver
            if (distancia <= distanciaMaximaPermitida &&
                jugador.GetComponent<LinternaUsable>().nivelBateria <= 0 &&
                jugador.GetComponent<LinternaUsable>().nivelCordura < 25.0f)
            {
                Debug.Log("GameOver");

                DelegatesHelper.playCinematic.Invoke(0);
                this.gameObject.transform.position = new Vector3(377.840332f, 9.91821289e-05f, -81.5740738f);
                // Realiza otras acciones según sea necesario
            }
        }
    }
}

