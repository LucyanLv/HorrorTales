using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.EventSystems;

public class AudioCanvas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] EventReference mouseClick;

    [SerializeField] EventReference mouseEnter;

    private bool isMouseOver = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isMouseOver = true;
        RuntimeManager.PlayOneShot(mouseEnter);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isMouseOver = false;
    }

    public void PlaySoundEvent()
    {
        {
            RuntimeManager.PlayOneShot(mouseClick);
        }
    }


}
