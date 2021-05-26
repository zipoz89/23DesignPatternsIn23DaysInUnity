using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AutomataStrategy
{
    public abstract int[,] Iterate(int[,] map);
    protected int GetSurroundingCellCount(int gridX, int gridY, int[,] map)   //get non air blocks around block
    {
        int xBound = map.GetLength(0);
        int yBound = map.GetLength(1);
        int aliveCellCount = 0;
        for (int y = gridY - 1; y <= gridY + 1; y++) {
            for (int x = gridX - 1; x <= gridX + 1; x++) {
                if (x >= 0 && x < xBound && y >= 0 && y < yBound)
                    if (x != gridX || y != gridY)
                        if (map[x, y] != 0) aliveCellCount += map[x, y];

            }
        }
        return aliveCellCount;
    }

    protected int GetColseNeighboursCount(int gridX, int gridY, int[,] map) {
        int aliveCellCount = 0;
        if (gridX - 1 >= 0)
            if (map[gridX - 1, gridY] != 0) 
                aliveCellCount++;
        if (gridY - 1 >= 0)
            if (map[gridX, gridY - 1] != 0)
                aliveCellCount++;
        if (gridX + 1 < map.GetLength(0))
            if (map[gridX + 1, gridY] != 0)
                aliveCellCount++;
        if (gridY + 1 < map.GetLength(1))
            if (map[gridX, gridY + 1] != 0)
                aliveCellCount++;
        return aliveCellCount;
    }

}

public class GameOfLifeAutomata : AutomataStrategy {
    public override int[,] Iterate(int[,] map) {
        int[,] newMap = new int[map.GetLength(0), map.GetLength(1)];
        for (int x = 0; x < map.GetLength(0); x++) {
            for (int y = 0; y < map.GetLength(1); y++) {
                int cellCount = GetSurroundingCellCount(x, y, map);
                if (cellCount != 0)          
                if (map[x, y] != 0) {
                    if (cellCount < 2) {
                            newMap[x, y] = 0;
                        continue;
                    }
                    if (cellCount > 3) {
                            newMap[x, y] = 0;
                        continue;
                    }
                    else {
                            newMap[x, y] = 1;
                        continue;
                    }
                }
                if (map[x, y] == 0 && cellCount == 3) {
                    newMap[x, y] = 1;
                    continue;
                }
                else newMap[x, y] = 0;
            }
        }
        return newMap;
    }


}


public class Rule942Automata : AutomataStrategy {
    public override int[,] Iterate(int[,] map) {
        int[,] newMap = new int[map.GetLength(0), map.GetLength(1)];
        for (int x = 0; x < map.GetLength(0); x++) {
            for (int y = 0; y < map.GetLength(1); y++) {
                int cellCount = GetColseNeighboursCount(x, y, map);
                if (cellCount == 1 || cellCount == 4) {
                    newMap[x, y] = 1;
                }
                else newMap[x, y] = map[x, y];
            }
        }
        return newMap;
    }
}

public class CaveGenerationAutomata : AutomataStrategy {
    public override int[,] Iterate(int[,] map) {
        int[,] newMap = new int[map.GetLength(0), map.GetLength(1)];
        for (int x = 0; x < map.GetLength(0); x++) {
            for (int y = 0; y < map.GetLength(1); y++) {
                int neighbourWallTiles = GetSurroundingCellCount(x, y, map);
                if (neighbourWallTiles > 4) {
                    map[x, y] = 1;
                }
                else if (neighbourWallTiles < 4) {
                    map[x, y] = 0;
                }
            }
        }
        return map;
    }

}
