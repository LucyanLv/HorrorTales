using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ESCpause : MonoBehaviour
{
    [SerializeField] private GameObject botonpausa;

    [SerializeField] private GameObject menupausa;

    private bool juegopausado = false;


    private void Start()
    {

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegopausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        juegopausado = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None; // Desactiva el cursor lock
        Cursor.visible = true; // Haz que el cursor sea visible
        botonpausa.SetActive(false);
        menupausa.SetActive(true);
    }

    public void Reanudar()
    {
        juegopausado = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked; // Reactiva el cursor lock
        Cursor.visible = false; // Oculta el cursor
        botonpausa.SetActive(true);
        menupausa.SetActive(false);
    }

    public void Reiniciar()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {



            SceneManager.LoadScene("New Scene");
        }


        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Cerrar()
    {
        Application.Quit();
    }
    public void Menuinicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}
