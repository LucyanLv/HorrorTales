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
        if (other.CompareTag("Player"))
        {
            Bounds item = GetBoundsWithMargin(GetComponent<Renderer>().bounds, 0.1f);
            camFOV = GeometryUtility.CalculateFrustumPlanes(Camera.main);

            if (IsElementVisible(gameObject, 0.1f))
            {
                Debug.Log("element visible in camera");
                Vector2 position = Camera.main.WorldToScreenPoint(gameObject.transform.position);
                TooltipManager.Instance.setAndShowToolTip("V", position + Vector2.up * 60);
              
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("vamo a clickear");
                    GetComponent<PuzzlePart>().wasClicked();
                    TooltipManager.Instance.hideToolTip();
                }
            }
            else
            {
                Debug.Log("element NOT NOT NOT visible in camera");
                TooltipManager.Instance.hideToolTip();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TooltipManager.Instance.hideToolTip();
    }

    private bool IsElementVisible(GameObject elemento, float margen)
    {
        Renderer renderer = elemento.GetComponent<Renderer>();
        Debug.Log($"entro a validar visible");

        if (renderer != null)
        {
            Debug.Log($"entro pues el renderer np es null ");
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
