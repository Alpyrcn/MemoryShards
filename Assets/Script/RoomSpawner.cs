using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    private RoomPrefabs roomPrefab;
    private int rand;
    private bool spawned = false;

    public float waitTime = 4f;
    private void Start()
    {
        Destroy(gameObject, waitTime);
        roomPrefab = GameObject.FindGameObjectWithTag("RoomSpawn").GetComponent<RoomPrefabs>();
        Invoke("Spawn", 0.1f);
    }


    void Spawn()
    {

        if(spawned == false)
        {
            if (openingDirection == 0)
            {
                rand = Random.Range(0, roomPrefab.EntryRooms.Length);
                Instantiate(roomPrefab.EntryRooms[rand], transform.position, roomPrefab.EntryRooms[rand].transform.rotation);

            }

            else if (openingDirection == 1)
            {
                rand = Random.Range(0, roomPrefab.bottomRooms.Length);
                Instantiate(roomPrefab.bottomRooms[rand], transform.position, roomPrefab.bottomRooms[rand].transform.rotation);

            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, roomPrefab.topRooms.Length);
                Instantiate(roomPrefab.topRooms[rand], transform.position, roomPrefab.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, roomPrefab.leftRooms.Length);
                Instantiate(roomPrefab.leftRooms[rand], transform.position, roomPrefab.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, roomPrefab.rightRooms.Length);
                Instantiate(roomPrefab.rightRooms[rand], transform.position, roomPrefab.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(roomPrefab.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
