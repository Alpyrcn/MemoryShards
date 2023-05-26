using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMapGenerator : MonoBehaviour
{
    [SerializeField]
    protected TilemapVisualzer tilemapvisualzer = null;
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;

    public void GenerateDungeon()
    {
        tilemapvisualzer.Clear();
        RunGenerateDungeon();
    }

    protected abstract void RunGenerateDungeon();
}
