using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator 
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualzer tilemapvisualzer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionsList);
        foreach (var position in basicWallPositions)
        {
            tilemapvisualzer.PaintSingleBasicWall(position);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionsList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var positions in floorPositions)
        {
            foreach (var direction in directionsList)
            {
                var neigbourPosition = positions + direction;
                if (floorPositions.Contains(neigbourPosition) == false)
                {
                    wallPositions.Add(neigbourPosition);
                }
            }
        }

        return wallPositions;
    }
}
