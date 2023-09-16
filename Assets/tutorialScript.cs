using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialScript : MonoBehaviour
{
    [Header("Aprender a Caminar")]
    [SerializeField] GameObject aprenderCaminar;

    [Header("Aprender a usar linterna")]
    [SerializeField] GameObject aprenderLinterna;
    [SerializeField] GameObject medidor;

    private bool linternaUsada = false;

    // Start is called before the first frame update
    void Start()
    {
        aprenderCaminar.SetActive(true);
        aprenderLinterna.SetActive(false);
        medidor.SetActive(false);
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
            aprenderLinterna.SetActive(false);
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
    }
}
