using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.EventSystems;

public class AudioCanvas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] string mouseClickEventPath = "event:/mouseClick"; // Ruta del evento de clic
    [SerializeField] string mouseEnterEventPath = "event:/mouseEnter"; // Ruta del evento de entrada

    private bool isMouseOver = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
        RuntimeManager.PlayOneShot(mouseEnterEventPath);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }

    public void PlaySoundEvent()
    {
        RuntimeManager.PlayOneShot(mouseClickEventPath);
    }
}
