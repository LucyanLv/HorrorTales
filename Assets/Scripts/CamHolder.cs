using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamHolder : MonoBehaviour
{
    [SerializeField] Transform camPos;
    [SerializeField] Transform playerVisionCenter;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = camPos.position;
        transform.LookAt(playerVisionCenter);
    }
}
