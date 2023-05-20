using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    [SerializeField] float pos_y_correction;
    [SerializeField] float pos_x_correction;
    [SerializeField] float pos_z_correction;

    void Start()
    {
        transform.position = GameObject.Find("Player").transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x - (pos_x_correction), player.position.y - (pos_y_correction), transform.position.z - (pos_z_correction));
    }
}

