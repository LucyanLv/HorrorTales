using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSectorManager : MonoBehaviour
{
    public static PlayerSectorManager Instance { get; private set; }

    public string currentSector { get; private set; } = "A";

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SetSector(string newSector)
    {
        currentSector = newSector;
        Debug.Log("Sector actual: " + newSector);
    }
}
