using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum DrawingMode {
    Draw,
    Erase
}

public interface DrawingState
{
    void SetCells(Vector3Int tileToSet, Tilemap tilemap, TileBase tile, DrawingMode mode, int radius);
}

public class CircleDrawingState : DrawingState {
    public void SetCells(Vector3Int tileToSet, Tilemap tilemap, TileBase tile, DrawingMode mode,int radius) {
        if (mode == DrawingMode.Erase) tile = null;
        if (radius != 0)
            for (int x = tileToSet.x - radius; x <= tileToSet.x + radius; x++) {
                for (int y = tileToSet.y - radius; y <= tileToSet.y + radius; y++) {
                    if ((x - tileToSet.x) * (x - tileToSet.x) + (y - tileToSet.y) * (y - tileToSet.y) <= radius * radius) {
                        Vector3Int finalPos = new Vector3Int(x, y, 0);

                        tilemap.SetTile(finalPos, tile);
                        tilemap.RefreshTile(finalPos);
                    }
                }
            }
        else {
            tilemap.SetTile(tileToSet, tile);
            tilemap.RefreshTile(tileToSet);
        }
    }
}
public class SquareDrawingState : DrawingState {
    public void SetCells(Vector3Int tileToSet, Tilemap tilemap, TileBase tile, DrawingMode mode, int radius) {
        if (mode == DrawingMode.Erase) tile = null;
        if (radius != 0)
            for (int x = tileToSet.x - radius; x < tileToSet.x + radius; x++) {
                for (int y = tileToSet.y - radius; y < tileToSet.y + radius; y++) {
                    Vector3Int finalPos = new Vector3Int(x, y, 0);
                    tilemap.SetTile(finalPos, tile);
                    tilemap.RefreshTile(finalPos);
                }
            }
        else {
            tilemap.SetTile(tileToSet, tile);
            tilemap.RefreshTile(tileToSet);
        }
    }
}
