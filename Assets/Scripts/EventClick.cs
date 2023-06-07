using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string message;

    void Awake()
    {
        //Debug.Log("awale del event clic uwu");
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
        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResultList);
        List<RaycastResult> a = raycastResultList.Where(t => t.gameObject.CompareTag("Collectable")).ToList();
        Debug.Log($"{a.Count} uwu los game objectsssssssssssssssssssssssssssssssssssssssssss     /////////////////  " );
        TooltipManager.Instance.setAndShowToolTip(message, eventData.position);
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
