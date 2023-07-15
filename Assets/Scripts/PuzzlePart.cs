using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePart : MonoBehaviour
{
    [SerializeField] private float id;
    private AudioSource audioSource;
    private SpriteRenderer[] imgs;
    private bool aumentado = false;
    public float Id { get => id; set => id = value; }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
         imgs = GetComponentsInChildren<SpriteRenderer>();
    }
    public void wasClicked()
    {
        Debug.Log($"111_{Id}");
        GameObject.Find($"111_{Id}").GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log($"111_{Id} mostrarse {GameObject.Find($"111_{Id}").GetComponent<SpriteRenderer>().enabled}");
        audioSource.Play();
        rotatePart();
        
    }

    private void Update()
    {
        if (aumentado)
        {
            transform.Rotate(Vector3.up * 0.5f);
            if (Input.GetMouseButtonDown(0))
            {
                //TODO ANIMACION DE DESAPARECER
                Destroy(this.gameObject);
            }
        }
    }
    private void rotatePart()
    {
        aumentado = true;
        Vector3 pos = new Vector3(Screen.width / 2, Screen.height / 2, 0.7f);
       
       
            transform.position = Camera.main.ScreenToWorldPoint(pos);
            transform.localScale *= 2f;
       
    }
}
