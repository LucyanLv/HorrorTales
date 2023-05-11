using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class ToolTipManager : MonoBehaviour
{
    public static ToolTipManager _instance;
    [SerializeField] private TextMeshProUGUI indicator;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
