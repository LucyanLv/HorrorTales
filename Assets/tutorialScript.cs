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

    private bool linternaUsada = false;
    private bool puertaAbierta = false;

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
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            Destroy(aprenderCaminar);
        }

        if (Input.GetMouseButtonDown(1) && aprenderLinterna.activeSelf)
        {
            Destroy(aprenderLinterna);
        }
        if(Input.GetMouseButtonDown(0) && aprenderPuerta.activeSelf)
        {
            Destroy(aprenderPuerta);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ObjetoLinterna" && !linternaUsada)
        {
            aprenderLinterna.SetActive(true);
            medidor.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                linternaUsada = true; // Marcar que se ha usado la linterna
            }
        }

        if (other.tag == "Bateria")
        {
            aprenderLocura.SetActive(true);
            StartCoroutine(destruirLocura());
        }

        if(other.tag == "Door" && !puertaAbierta)
        {
            aprenderPuerta.SetActive(true);
            if (Input.GetMouseButtonDown(1))
            {
                puertaAbierta = true;
            }
        }
    }

    IEnumerator destruirLocura ()
    {
        yield return new WaitForSecondsRealtime (5f);
        Destroy(aprenderLocura);
    }
}
