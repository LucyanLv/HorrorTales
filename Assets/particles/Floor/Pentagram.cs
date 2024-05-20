using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pentagram : MonoBehaviour
{
    [SerializeField] Material pentagramShader;
    [SerializeField] float appear;
    [SerializeField] float time;

    // Start is called before the first frame update
    void Start()
    {
        pentagramShader.SetFloat("_TimeAppear", appear);
        appear = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (appear <  time)
        {
            appear += Time.deltaTime / time;
        }

        else
        {
            appear = 1;
        }
        pentagramShader.SetFloat("_TimeAppear", appear);
    }
}

