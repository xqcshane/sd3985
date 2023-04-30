using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RandomEmeny : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public int EnemyNumber;
    void Start()
    {
        StartRandom();
        //mypre.transform.position = new Vector3(Random.Range(-rmx, rmx), Random.Range(-rmy, rmy),0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRandom(){
        for(int i=0;i<EnemyNumber;i++){
            float rmx = this.gameObject.GetComponent<BoxCollider2D>().bounds.size.x/2;
            float rmy = this.gameObject.GetComponent<BoxCollider2D>().bounds.size.y/2;

            Vector3 position = new Vector3(Random.Range(-rmx, rmx), Random.Range(1-rmy, rmy-1),0);
            GameObject mypre = PhotonNetwork.Instantiate(prefab.name, position+this.gameObject.transform.position, Quaternion.identity);
            mypre.transform.parent = this.gameObject.transform;
        }
    }
}
