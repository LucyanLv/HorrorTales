using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : Singleton<TooltipManager>
{
   [SerializeField] private TextMeshProUGUI textComponent;
    // Start is called before the first frame update
    void Awake(){
        Instance.GetInstanceID();
    }
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }
    
    public void setAndShowToolTip(string message, Vector3 elementPosition){
        transform.position = elementPosition;
        gameObject.SetActive(true);
        textComponent.text = message;
    }

    public void hideToolTip( ){
        gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }
}
