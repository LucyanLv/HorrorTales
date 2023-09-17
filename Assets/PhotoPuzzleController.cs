using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoPuzzleController : MonoBehaviour
{
    [SerializeField] PuzzlePart[] parts;
    bool allCollected = true;

    public void ValidateCollected()
    {
        
        foreach (var item in parts)
        {
            Debug.Log($"FOTO CON ID {item.Id} TIENE COLECTADO EN {item.Collected}");
            if (!item.Collected)
            {
                allCollected = false;
                break;
            }
        }
        if (allCollected)
        {
            Debug.Log("TODAS RECOLECTADAS");
        }
        else
            Debug.Log("no no no NO TODAS RECOLECTADAS");
    }
}
