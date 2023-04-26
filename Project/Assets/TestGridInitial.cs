using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGridInitial : MonoBehaviour
{
    public GameObject[] myGridsController;
    // Start is called before the first frame update
    void Start()
    {
        myGridsController = GameObject.FindGameObjectsWithTag("Grids");
        foreach(GameObject x in myGridsController)
        {
            x.GetComponent<GridsController>().initialGrid();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
