using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    [SerializeField] GameObject aprenderCaminar;
    [SerializeField] GameObject aprenderLinterna;
    [SerializeField] GameObject medidor;
    [SerializeField] GameObject aprenderLocura;
    [SerializeField] GameObject aprenderPuerta;

    [SerializeField] private bool linternaUsada = false;
    [SerializeField] private bool puertaAbierta = false;
    [SerializeField] private bool tutorialCompletado = false;

    // Start is called before the first frame update
    void Start()
    {
        aprenderCaminar.SetActive(true);
        aprenderLinterna.SetActive(false);
        medidor.SetActive(false);
        aprenderLocura.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!tutorialCompletado)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                Destroy(aprenderCaminar);
            }

            if (Input.GetMouseButtonDown(1) && aprenderLinterna.activeSelf)
            {
                Destroy(aprenderLinterna);
                linternaUsada = true;
            }

            if (Input.GetMouseButtonDown(0) && aprenderPuerta.activeSelf)
            {
                Destroy(aprenderPuerta);
                puertaAbierta = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!tutorialCompletado)
        {
            if (other.tag == "ObjetoLinterna" && !linternaUsada)
            {
                Debug.Log("Agarró la linterna");
                aprenderLinterna.SetActive(true);
                medidor.SetActive(true);

                if (Input.GetMouseButtonDown(0))
                {
                    linternaUsada = true;
                }
            }

            if (other.tag == "Bateria")
            {
                aprenderLocura.SetActive(true);
                StartCoroutine(DestroyAfterDelay(aprenderLocura, 5f));
            }

            if (other.tag == "Door" && !puertaAbierta)
            {
                aprenderPuerta.SetActive(true);
                if (Input.GetMouseButtonDown(1))
                {
                    puertaAbierta = true;
                }
            }

            // Verificar si se ha completado el tutorial
            if (linternaUsada && puertaAbierta && aprenderCaminar == null && aprenderLinterna == null && aprenderPuerta == null)
            {
                tutorialCompletado = true;
            }
        }
    }

    IEnumerator DestroyAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        Destroy(obj);
    }
}
