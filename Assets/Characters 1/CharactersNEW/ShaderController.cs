using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderController : MonoBehaviour
{
    public Shader shader;

    private void Start()
    {
        shader = GetComponent<Shader>();
    }
    private void Update()
    {
        
    }
}
