using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "New Enemy Data", order =51)]
public class EnemyData : ScriptableObject
{

    public int health;
    public float speed;
    public int damage;
}
