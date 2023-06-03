using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
   [SerializeField] private string message;
   
   void Awake(){
      Debug.Log("awale del event clic uwu");
   }
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
      List<GameObject> a = eventData.hovered;
      Debug.Log(a.Count);
      TooltipManager.Instance.setAndShowToolTip(message, eventData.position   );
    }
    public void OnPointerExit(PointerEventData eventData)
    {
      //  throw new System.NotImplementedException();
      TooltipManager.Instance.hideToolTip();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       // throw new System.NotImplementedException();
    }
}
