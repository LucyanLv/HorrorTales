using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour
{

    private FullScreenPassRendererFeatureEditor _distance;
    private Ray _visionRay;
    [SerializeField] private float radius;
    [SerializeField] private float angle;

    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstacleMask;

    [SerializeField] private bool canSeeItem;
    // Start is called before the first frame update
    void Start()
    {
    // https://www.youtube.com/watch?v=j1-OyLo77ss
    }

    // Update is called once per frame
    void Update()
    {
        _visionRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(_visionRay.origin, _visionRay.direction * 30f);
    }
}
