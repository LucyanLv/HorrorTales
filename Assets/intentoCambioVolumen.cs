using UnityEngine;
using FMODUnity;

public class ControladorSonido : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string eventoFMOD; // Asigna el evento FMOD a trav�s del Inspector.

    private FMOD.Studio.EventInstance eventoInstance;
    private FMOD.Studio.PARAMETER_ID volumenParameter;

    public Collider colliderGrande; // Asigna el collider grande desde el Inspector.
    public Collider colliderPequeno; // Asigna el collider peque�o desde el Inspector.

    private bool jugadorDentroCollider = false;

    void Start()
    {
        // Inicializa el evento FMOD y obt�n una instancia.
        eventoInstance = RuntimeManager.CreateInstance(eventoFMOD);

        // Obtiene la instancia del par�metro "Volumen".
        eventoInstance.getParameterByName("Volumen", out volumenParameter);

        // Comienza a reproducir el evento.
        eventoInstance.start();
    }

    void Update()
    {
        // Verifica si el jugador est� dentro del collider grande.
        if (jugadorDentroCollider)
        {
            // Calcula la distancia entre el personaje emisor y el jugador (usando el centro del collider grande).
            Vector3 emisorPosicion = colliderGrande.bounds.center;
            Vector3 jugadorPosicion = colliderPequeno.bounds.center;

            float distancia = Vector3.Distance(emisorPosicion, jugadorPosicion);

            // Calcula el valor del par�metro "Volumen" basado en la distancia.
            float valorVolumen = Mathf.Lerp(100f, 0f, distancia / colliderGrande.bounds.extents.magnitude);

            // Actualiza el par�metro "Volumen" en FMOD en tiempo real.
            volumenParameter.setValue(valorVolumen);
        }
        else
        {
            // Si el jugador no est� dentro del collider grande, det�n el sonido.
            eventoInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Si el jugador entra en el collider grande, marca que est� dentro.
        if (other.CompareTag("Player"))
        {
            jugadorDentroCollider = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del collider grande, marca que est� fuera.
        if (other.CompareTag("Player"))
        {
            jugadorDentroCollider = false;
        }
    }

    void OnDestroy()
    {
        // Det�n y libera la instancia del evento FMOD cuando el objeto sea destruido.
        eventoInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        eventoInstance.release();
    }
}



//using UnityEngine;
//using FMODUnity;
//using Unity.VisualScripting;

//public class intentiCambioVolumen : MonoBehaviour
//{
//    [SerializeField] private StudioEventEmitter eventEmitter;
//    [SerializeField] private Transform player;

//    private void Update()
//    {

//        // Calcula la distancia entre el jugador y el emisor de sonido
//        float volumen = 25 + (Vector3.Distance(transform.position, player.position) / 300) * 75;

//        Debug.Log(volumen);
//        // Ajusta el valor del par�metro "Distancia" en FMOD seg�n la distancia
//        eventEmitter.SetParameter("Volumen", volumen);
//        Debug.Log("Volumen Actual " + volumen)
//    }
//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            // Calcula la distancia entre el jugador y el emisor de sonido
//            float volumen = Vector3.Distance(transform.position, player.position);

//            Debug.Log(volumen);
//            // Ajusta el valor del par�metro "Distancia" en FMOD seg�n la distancia
//            eventEmitter.SetParameter("Volumen", volumen);
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            // Cuando el jugador sale del trigger, puedes restablecer el par�metro a su valor predeterminado si es necesario.
//            eventEmitter.SetParameter("Volumen", 0f); // Establece el valor predeterminado aqu�.
//        }
//    }
//}
