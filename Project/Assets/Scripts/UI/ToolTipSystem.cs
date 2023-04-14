using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipSystem : MonoBehaviour
{
    private static ToolTipSystem current;

    public ToolTip tooltip;
    // Start is called before the first frame update
    void Awake()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Show(string content, string header = ""){
        current.tooltip.SetText(content,header);
        current.tooltip.gameObject.SetActive(true);
    }
    public static void Hide(){
        current.tooltip.gameObject.SetActive(false);
    }
}
