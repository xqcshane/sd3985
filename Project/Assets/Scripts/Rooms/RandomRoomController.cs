using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoomController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] RandomRooms;
    public GameObject[] RoomPrefabs;
    void Start()
    {        
        int[] randomint = UniqRandom(RoomPrefabs.Length, RandomRooms.Length);

        for(int i=0; i < RandomRooms.Length; i++)
        {
            GameObject MyRoom = Instantiate(RoomPrefabs[randomint[i]], RandomRooms[i].transform.position, Quaternion.Euler(0, 0, 0));
            MyRoom.transform.parent = RandomRooms[i].gameObject.transform;
        }
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
}
