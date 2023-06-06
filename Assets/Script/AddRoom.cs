using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomPrefabs roomprefab;

    void Start()
    {
        roomprefab = GameObject.FindGameObjectWithTag("RoomSpawn").GetComponent<RoomPrefabs>();
        roomprefab.rooms.Add(this.gameObject);
    }
}
