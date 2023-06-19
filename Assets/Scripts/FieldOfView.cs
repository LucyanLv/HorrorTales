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

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
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
                Bounds item = GetBoundsWithMargin(other.gameObject.GetComponent<Renderer>().bounds, 0.1f);


                if (GeometryUtility.TestPlanesAABB(camFOV, item))
                {
                    Debug.Log($"LO VEO LO VEOOOOO");
                    camFOV = GeometryUtility.CalculateFrustumPlanes(Camera.main);

                    if (IsElementVisible(other.gameObject, 0.1f))
                    {
                        Debug.Log("element visible in camera");
                        Vector2 position = Camera.main.WorldToScreenPoint(other.gameObject.transform.position);
                         //Debug.Log($"{position} - uwu los game objects desde el script de fiel of view     /////////////////  ");
                         TooltipManager.Instance.setAndShowToolTip("V", position + Vector2.up * 60);
                    }
                    else
                    {
                        TooltipManager.Instance.hideToolTip();

                    }
                }
            }
        }
    }


    private bool IsElementVisible(GameObject elemento, float margen)
    {
        Renderer renderer = elemento.GetComponent<Renderer>();
        Debug.Log($"entro a validar visible");

        if (renderer != null)
        {
            // Comprueba si algún punto del renderer del elemento está dentro del frustum
            return GeometryUtility.TestPlanesAABB(camFOV, renderer.bounds) ||
                   GeometryUtility.TestPlanesAABB(camFOV, GetBoundsWithMargin(renderer.bounds, margen));
        }

        // Si el elemento no tiene un Renderer, verifica si algún punto del Transform está dentro del frustum
        return GeometryUtility.TestPlanesAABB(camFOV, new Bounds(elemento.transform.position, Vector3.zero));
    }

    private Bounds GetBoundsWithMargin(Bounds bounds, float margin)
    {
        Vector3 marginVector = new Vector3(bounds.extents.x * margin, bounds.extents.y * margin, bounds.extents.z * margin);
        return new Bounds(bounds.center, bounds.size + marginVector);
    }
}
