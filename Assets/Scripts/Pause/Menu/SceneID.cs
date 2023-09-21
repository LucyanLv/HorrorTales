using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneID : MonoBehaviour
{
    public int sceneID;
    public void ChangeSceneID()
    {
        ChangeScene1.tagScene = sceneID;
        Cursor.lockState = CursorLockMode.None; // Desactiva el cursor lock
        Cursor.visible = true; // Haz que el cursor sea visible
    }
}
