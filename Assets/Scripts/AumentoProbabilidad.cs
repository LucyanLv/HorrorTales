using UnityEngine;

public class AumentoProbabilidad : MonoBehaviour
{
    [SerializeField] private float aumentoDeProbabilidad = 0.5f; // La cantidad en la que aumentar� la probabilidad

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Obt�n una referencia al script "LinternaUsable" del jugador
            LinternaUsable linternaScript = other.GetComponent<LinternaUsable>();

            if (linternaScript != null)
            {
                // Aumenta el valor de "valorProbabilidadControlado"
                linternaScript.valorProbabilidadControlado += aumentoDeProbabilidad;

                // Puedes imprimir un mensaje para verificar que se ha aumentado la probabilidad
                Debug.Log("Valor de probabilidad aumentado: " + linternaScript.valorProbabilidadControlado);

                linternaScript.ActualizarNivelCordura(1);

                Destroy(this.gameObject);
            }
        }
    }
}
