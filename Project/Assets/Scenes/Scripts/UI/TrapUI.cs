using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TrapUI : MonoBehaviour
{
    private Image ThisImage;
    public Image ContentImage;
    public TextMeshProUGUI TextNumber;

    // Start is called before the first frame update
    void Start()
    {
        ThisImage = this.gameObject.GetComponent<Image>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChooseTrap()
    {
        ThisImage.color = Color.red;
    }

    public void UnChooseTrap()
    {
        ThisImage.color = Color.white;
    }

    public void ChangeTrapImage(Sprite TrapImg)
    {
        ContentImage.sprite = TrapImg;
    }
    public void ChangeTrapNumber(string NewNumberInString)
    {
        TextNumber.text = NewNumberInString;
    }
}
