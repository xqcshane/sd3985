using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
    private static LTDescr delay;
    public string header;

    [Multiline()]
    public string content;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData){
        delay = LeanTween.delayedCall(0.5f,()=>{
            ToolTipSystem.Show(content, header);
        });
        
    }
    
    public void OnPointerExit(PointerEventData eventData){
        LeanTween.cancel(delay.uniqueId);
        ToolTipSystem.Hide();
    }
}
