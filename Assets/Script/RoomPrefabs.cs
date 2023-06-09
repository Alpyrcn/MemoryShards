using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPrefabs : MonoBehaviour
{
    public GameObject largeRoom;
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] EntryRooms;

    public GameObject closedRoom;

    public GameObject[] Painting;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    private bool largeroomspawn;
    public GameObject boss;

    void Update()
    {
        if(waitTime <= 0 && spawnedBoss == false)
        {

            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        } else {
            waitTime -= Time.deltaTime;
        }

    }

}
