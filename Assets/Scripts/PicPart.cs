using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicPart : MonoBehaviour
{
    [SerializeField] private float id;

    public float Id { get => id; set => id = value; }

    public void wasClicked()
    {
        Debug.Log($"111_{Id}");
        GameObject.Find($"111_{Id}").GetComponent<SpriteRenderer>().enabled = true;
    }
}
