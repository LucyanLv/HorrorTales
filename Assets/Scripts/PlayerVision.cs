using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour
{

    private FullScreenPassRendererFeatureEditor _distance;
    private Ray _visionRay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _visionRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(_visionRay.origin, _visionRay.direction * 30f);
    }
}
