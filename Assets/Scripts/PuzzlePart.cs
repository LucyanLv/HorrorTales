using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePart : MonoBehaviour
{
    [SerializeField] private float id;
    private AudioSource audioSource;
    public float Id { get => id; set => id = value; }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void wasClicked()
    {
        Debug.Log($"111_{Id}");
        GameObject.Find($"111_{Id}").GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log($"111_{Id} mostrarse {GameObject.Find($"111_{Id}").GetComponent<SpriteRenderer>().enabled}");
        audioSource.Play();
        Destroy(this.gameObject);
    }
}
