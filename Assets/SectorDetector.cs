using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorDetector : MonoBehaviour
{
    [SerializeField] string sectorID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSectorManager.Instance?.SetSector(sectorID);
        }
    }
}
