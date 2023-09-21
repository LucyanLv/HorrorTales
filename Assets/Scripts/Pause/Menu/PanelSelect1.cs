using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class PanelSelect1 : MonoBehaviour
{
    public int panelSelect;
    public void changePanel()
    {
        PanelManager1.panel = panelSelect;
    }
}
