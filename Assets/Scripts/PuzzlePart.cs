using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePart : MonoBehaviour
{
    [SerializeField] private float id;
    private bool collected = false;
    public float Id { get => id; set => id = value; }
    public bool Collected { get => collected; set => collected = value; }

    public float zoomin;

    [SerializeField] GameObject image;
    
    private void OnTriggerEnter(Collider other)
    {
        image.SetActive(true);
        collected = true;
        GameObject.Find("Recollected").GetComponent<UnityEngine.UI.Image>().overrideSprite = image.GetComponent<UnityEngine.UI.Image>().sprite;
        GameObject.Find("Recollected").GetComponent<UnityEngine.UI.Image>().enabled = true;
        GameObject.Find("Recollected").SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        GameObject.FindObjectOfType<PhotoPuzzleController>().ValidateCollected();
        // ACA VA TODO LO DE FMOD PARA HACER SONAR LA AGARRADA

    }
}
