using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class ControladorLinterna : MonoBehaviour
{
    [SerializeField] HDAdditionalLightData linterna;
    [SerializeField] int distanciaMaximaLuz;
    [SerializeField] LayerMask capaLinterna;
    RaycastHit hit;
    Ray rayo;
    [SerializeField] float distancia;
    [Range(20, 1000)] [SerializeField] float intento;
    // Start is called before the first frame update
    void Start()
    {
        linterna = GetComponent<HDAdditionalLightData>();
    }

    // Update is called once per frame
    void Update()
    {
        linterna.intensity = ReturnedValue(distancia, 3, intento, 87, 40000);
    }

    private void FixedUpdate()
    {
        rayo = new Ray(transform.position, transform.forward);
        Physics.Raycast(rayo, out hit, distanciaMaximaLuz, capaLinterna);
        Debug.DrawLine(transform.position, transform.forward * distanciaMaximaLuz, Color.white);

        distancia = hit.collider ? Vector3.Distance(transform.position, hit.point) : 1000;
        Debug.Log(ReturnedValue(distancia, 0, 100, 0, 40000));
        linterna.intensity = ReturnedValue(distancia, 0, 100, 0, 40000);
    }
    public void Enciende()
    {
        gameObject.SetActive(true);
    }

    public void Apaga()
    {
        gameObject.SetActive(false);
    }

    public float ReturnedValue(float value, float originalMin, float originalMax, float targetMin, float targetMax)
    {
        value = Mathf.Clamp(value, originalMin, originalMax);

        float originalRange = originalMax - originalMin;
        float targetRange = targetMax - targetMin;
        float normalizedValue = (value - originalMin) / originalRange;

        float mappedValue = (normalizedValue * targetRange) + targetMin;

        return mappedValue;
    }


}
