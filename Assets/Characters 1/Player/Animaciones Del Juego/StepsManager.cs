using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StepsManager: MonoBehaviour
{
    private float distance = 0.1f;

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector2.down * distance, Color.yellow);
    }

    void PlayFootStepsEvent(string path)
    {
        FMOD.Studio.EventInstance FootSteps = FMODUnity.RuntimeManager.CreateInstance(path);
        FootSteps.start();
        FootSteps.release();
    }
}
