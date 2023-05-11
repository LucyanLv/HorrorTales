using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log($"me han clikeado { GetComponent<PicPart>().Id}");
        GetComponent<PicPart>().wasClicked();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       // throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       // throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      //  throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       // throw new System.NotImplementedException();
    }
}
