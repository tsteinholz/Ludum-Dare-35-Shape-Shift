using UnityEngine;
using System.Collections;
using System;

public class LevelGeneration : MonoBehaviour {

    public string seed;
    public bool useRandomSeed;

    public Transform player;

    int[,] map;
    public int mapWidth;
    public int mapHeight;

    [Range(0, 100)]
    public int randomFillPercent;

	//Starts Level Generation
	void Start () {
        GenerateMap();
        DrawTileMap();
	}

    //Calls All Necessary Methods to Generate Map
    void GenerateMap()
    {
        map = new int[mapWidth, mapHeight];
        RandomFillMap();

        for (int i = 0; i < 3; i++)
            ConsolidateMap();
    }

    //Fills the Initial Map Array
    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }

            System.Random mapValue = new System.Random(seed.GetHashCode());

            for (int x = 0; x < mapWidth; x++)
            {
                for(int y = 0; y < mapHeight; y++)
                {
                    if (x == 0 || x == mapWidth - 1 || y == 0 || y == mapHeight - 1)
                        map[x, y] = 1;
                    else
                        map[x, y] = (mapValue.Next(0, 100) < randomFillPercent) ? 1 : 0;
                }
            }
    }

    //Refines the map, merges masses of squares to make a coherent cave/grouping
    void ConsolidateMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                int neighbourWallTiles = GetAdjacentWalls(x, y);

                if (neighbourWallTiles > 4)
                    map[x, y] = 1;
                else if (neighbourWallTiles < 4)
                    map[x, y] = 0;
            }
        }
    }

    //Returns the number of walls neighboring the selected cell.
    int GetAdjacentWalls(int gridX, int gridY)
    {
        int wallCount = 0;
        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
        {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
            {
                if (neighbourX >= 0 && neighbourX < mapWidth && neighbourY >= 0 && neighbourY < mapHeight)
                {
                    if (neighbourX != gridX || neighbourY != gridY)
                    {
                        wallCount += map[neighbourX, neighbourY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }

        return wallCount;
    }

    void DrawTileMap()
    {
        if (map != null)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (map[x, y] == 1)
                    {
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = new Vector3(-mapWidth / 2 + x*.5f + .5f, -mapHeight / 2 + y*.5f + .5f, 0);
                        cube.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                        cube.layer = 8;
                    }
                }
            }
        }
    }
}
