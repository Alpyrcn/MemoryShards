using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;

public class RandomDungeonGenerator : AbstractMapGenerator
{

    [SerializeField]
    private RandomWalkSO randomwalkparameters;




    protected override void RunGenerateDungeon()
    {
        HashSet<Vector2Int> floorPositions = RunRandomWalk();
        tilemapvisualzer.PaintFloorTiles(floorPositions);
        tilemapvisualzer.Clear();
        WallGenerator.CreateWalls(floorPositions, tilemapvisualzer);
        
    }

    protected HashSet<Vector2Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < randomwalkparameters.iterations; i++)
        {
            var path = MapGeneratorAlgorithms.SimpleRandomWalk(currentPosition, randomwalkparameters.walkLength);
            floorPositions.UnionWith(path);

            if (randomwalkparameters.startRandomlyEachIteration)
            {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
        return floorPositions;
    }

}
