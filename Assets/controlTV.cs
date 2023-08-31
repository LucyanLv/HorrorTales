using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlTV : MonoBehaviour
{
    [SerializeField] GameObject sonidoCarne;
    [SerializeField] GameObject noticiaTV;

    bool meatSound;
    bool notice;
    private void Start()
    {
        meatSound = true;
        notice = false;
    }
    private void Update()
    {
        if (meatSound == true)
        {
            sonidoCarne.SetActive(true);
        }

        if (notice == true)
        {
            noticiaTV.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(gameObject.CompareTag("Player") && Input.GetMouseButtonUp(0))
        {
            notice = false;
        }
    }
}
