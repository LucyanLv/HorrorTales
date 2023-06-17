using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private float visionAngle;
    [SerializeField] private SphereCollider visionCollider;
    [SerializeField] private bool itemSeen;
    Plane[] camFOV;
    void Awake()
    {
        visionCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Vector3 direccion = other.transform.position - transform.position;
            float angulo = Vector3.Angle(direccion, transform.forward);
            // Debug.Log($"{angulo}  / {visionAngle}");
            if (angulo < visionAngle + 0.5f)
            {

                // RaycastHit hit;

                // if (Physics.Raycast(transform.position + transform.up, direccion, out hit, visionCollider.radius))
                // {

                //     Debug.DrawRay(transform.position + transform.up, direccion, Color.magenta);

                //     if (hit.collider.gameObject.CompareTag("Collectable"))
                //     {
                //         itemSeen = true;
                //         Vector2 position = Camera.main.WorldToScreenPoint(other.gameObject.transform.position);
                //         Debug.Log($"{position} - uwu los game objects desde el script de fiel of view     /////////////////  ");
                //         TooltipManager.Instance.setAndShowToolTip("V", position + Vector2.up * 60);
                //     }
                // }
                Bounds item = (other.gameObject.GetComponent<Renderer>().bounds);


                if (GeometryUtility.TestPlanesAABB(camFOV, item))
                {
                    Debug.Log($"LO VEO LO VEOOOOO");
                    camFOV = GeometryUtility.CalculateFrustumPlanes(Camera.main);

                    if (IsElementVisible(other.gameObject.transform, 0.1f))
                    {
                        Vector2 position = Camera.main.WorldToScreenPoint(other.gameObject.transform.position);
                         Debug.Log($"{position} - uwu los game objects desde el script de fiel of view     /////////////////  ");
                         TooltipManager.Instance.setAndShowToolTip("V", position + Vector2.up * 60);
                    }
                    else
                    {
                        // El elemento está fuera del campo de visión de la cámara
                        // Realiza las acciones necesarias aquí
                    }
                }
            }
        }
    }


    private bool IsElementVisible(Transform elemento, float margen)
    {
        Renderer renderer = elemento.GetComponent<Renderer>();

        if (renderer != null)
        {
            // Comprueba si algún punto del renderer del elemento está dentro del frustum
            return GeometryUtility.TestPlanesAABB(camFOV, renderer.bounds) ||
                   GeometryUtility.TestPlanesAABB(camFOV, GetBoundsWithMargin(renderer.bounds, margen));
        }

        // Si el elemento no tiene un Renderer, verifica si algún punto del Transform está dentro del frustum
        return GeometryUtility.TestPlanesAABB(camFOV, new Bounds(elemento.position, Vector3.zero));
    }

    private Bounds GetBoundsWithMargin(Bounds bounds, float margin)
    {
        Vector3 marginVector = new Vector3(bounds.extents.x * margin, bounds.extents.y * margin, bounds.extents.z * margin);
        return new Bounds(bounds.center, bounds.size + marginVector);
    }
}
