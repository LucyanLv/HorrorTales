using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PhotoPuzzleController : MonoBehaviour
{
    [SerializeField] PuzzlePart[] parts;
    bool allCollected = true;

    [SerializeField] Door puerta;

    public void ValidateCollected()
    {
        PuzzlePart[] yaRecolectados = parts.Where(obj => obj.Collected).ToArray();
        //foreach (var item in parts)
        //{
        //    Debug.Log($"FOTO CON ID {item.Id} TIENE COLECTADO EN {item.Collected}");
        //    if (!item.Collected)
        //    {
        //        allCollected = false;
        //        break;
        //    }
        //}
        allCollected = yaRecolectados.Length == parts.Length;

        if (yaRecolectados.Length == 4)
        {
            puerta.UnlockDoor();
        }

        if (allCollected)
        {

            Debug.Log("TODAS RECOLECTADAS");
        }
        else
            Debug.Log("no no no NO TODAS RECOLECTADAS");
    }
}
