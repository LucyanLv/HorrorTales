using UnityEngine;

public class WallCullingDistance : MonoBehaviour
{
    [SerializeField] private float cullingDistance = 5f; // Distancia de culling para las paredes

    private Camera playerCamera;

    private void Start()
    {
        playerCamera = Camera.main;
    }

    private void Update()
    {
        // Ajustar la distancia de culling de las paredes basado en la posición del jugador
        if (playerCamera != null)
        {
            playerCamera.layerCullDistances = new float[] { cullingDistance };
        }
    }
}
