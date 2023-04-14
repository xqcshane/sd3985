using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    public TextMeshProUGUI headerField;
    public TextMeshProUGUI contentField;
    public LayoutElement layoutField;
    public int characterWrapLimit;
    public RectTransform rectTransform;

    public void Awake(){
        rectTransform = GetComponent<RectTransform>();
    }


    public void SetText(string content, string header = ""){
        if (string.IsNullOrEmpty(header)){
            headerField.gameObject.SetActive(false);
        }else{
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }
        contentField.text = content;
        SuitSize();
    }


    void Update()
    {
        SuitSize();

        Vector2 position = Input.mousePosition;
        
        float pivotX = position.x/Screen.width;
        float pivotY = position.y/Screen.height;

        rectTransform.pivot = new Vector2(pivotX,pivotY);
        transform.position = position;
    }

    private void SuitSize(){
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutField.enabled = (headerLength > characterWrapLimit || contentLength>characterWrapLimit) ? true:false;
    }
}
