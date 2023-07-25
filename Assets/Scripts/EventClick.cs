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
        Debug.Log($"me han clikeado { GetComponent<PuzzlePart>().Id}");
        GetComponent<PuzzlePart>().wasClicked();
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
        GameObject item = a[0].gameObject;
        item.GetComponent<AudioSource>().Play();
        //     Vector2 position = Camera.main.WorldToScreenPoint(t.position); 
        //     Debug.Log($"{ position } - uwu los game objectsssssssssssssssssssssssssssssssssssssssssss     /////////////////  ");
        //     TooltipManager.Instance.setAndShowToolTip(message, position + Vector2.up * 60);
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
