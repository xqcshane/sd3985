using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using HashTable = ExitGames.Client.Photon.Hashtable;

public class RoomRandomController : MonoBehaviourPunCallbacks 
{
    public GameObject[] RandomRooms;
    public GameObject[] RoomPrefabs;
    public GameObject BossRoomPrefabs;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int[] UniqRandom(int RandomNumber, int NeedNumber)
    {
        int[] randomskills = new int[NeedNumber];
        int maxnumber = 0;
        while (maxnumber < NeedNumber)
        {
            int num = Random.Range(1, RandomNumber+ 1);
            bool isOnList = false;
            foreach (int i in randomskills)
            {
                if (i == num)
                {
                    isOnList = true;
                }
            }
            if (!isOnList)
            {
                randomskills[maxnumber] = num;
                maxnumber++;
            }
        }
        for (int i = 0; i < randomskills.Length; i++)
        {
            randomskills[i] = randomskills[i] - 1;
        }
        return randomskills;
    }

    public void StartRandomRooms(){
        
        int[] randomint = UniqRandom(RoomPrefabs.Length, RandomRooms.Length);
        int bossroomposition = Random.Range(0, 4);
        randomint[bossroomposition] = -1;
        GameObject MyRoom;
        for (int i=0; i < RandomRooms.Length; i++)
        {
            if (randomint[i] != -1)
            {
                MyRoom = PhotonNetwork.Instantiate(RoomPrefabs[randomint[i]].name, RandomRooms[i].transform.position, Quaternion.Euler(0, 0, 0));
            }
            else
            {
                MyRoom = PhotonNetwork.Instantiate(BossRoomPrefabs.name, RandomRooms[i].transform.position, Quaternion.Euler(0, 0, 0));
            }

            MyRoom.transform.parent = RandomRooms[i].gameObject.transform;
        }
        GameObject.FindGameObjectWithTag("Status").GetComponent<Status>().changeRoomInfo(randomint);
    }

    public void StartFixedRooms(int[] roomindex)
    {
        GameObject MyRoom;
        for (int i = 0; i < RandomRooms.Length; i++)
        {
            if (roomindex[i] != -1)
            {
                MyRoom = PhotonNetwork.Instantiate(RoomPrefabs[roomindex[i]].name, RandomRooms[i].transform.position, Quaternion.Euler(0, 0, 0));
            }
            else
            {
                MyRoom = PhotonNetwork.Instantiate(BossRoomPrefabs.name, RandomRooms[i].transform.position, Quaternion.Euler(0, 0, 0));
            }
            MyRoom.transform.parent = RandomRooms[i].gameObject.transform;
        }
    }
}
