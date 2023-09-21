using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LockThisDoor : MonoBehaviour
{
    [SerializeField] Door puerta;

    private void OnTriggerEnter(Collider other)
    {
        Input.GetMouseButton(0);
        puerta.doorLocked = true;
    }
}
