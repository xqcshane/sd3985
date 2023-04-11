using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerCreater : MonoBehaviour
{
    [SerializeField]
    private Camera uiCamera;
    public GameObject Game_Pointer_ui_preferb;
    public string MyTag;
    public float PointerImageOrignalRoutate;
    private GameObject[] MyFindItems;
    // Start is called before the first frame update
    void Start()
    {
        MyFindItems = GameObject.FindGameObjectsWithTag(MyTag);
        foreach (GameObject Myitem in MyFindItems)
        {
            GameObject MyPointer = Instantiate(Game_Pointer_ui_preferb, this.transform);
            MyPointer.GetComponent<PointerToItems>().uiCamera = uiCamera;
            MyPointer.GetComponent<PointerToItems>().MyFindItem = Myitem;
            MyPointer.GetComponent<PointerToItems>().ImageOrignalRoutate = PointerImageOrignalRoutate;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
