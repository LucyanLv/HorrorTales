using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DelegatesHelper
{
    public delegate void PlayCinematic(int cinematicIndex);
    public static PlayCinematic playCinematic;

    public delegate void CinematicFinished(int cinematicIndex);
    public static CinematicFinished cinematicFinished;
}
