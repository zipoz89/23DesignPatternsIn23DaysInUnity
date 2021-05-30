using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PaintClone : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase tile;
    DrawingState[] states;
    int currentState = 0;
    DrawingMode mode = DrawingMode.Draw;
    [SerializeField] private int radius = 1;
    void Start()
    {
        states = new DrawingState[2];
        states[0] = new CircleDrawingState();
        states[1] = new SquareDrawingState();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (currentState == 0) currentState = 1;
            else currentState = 0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (mode == DrawingMode.Draw) mode = DrawingMode.Erase;
            else mode = DrawingMode.Draw;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            radius++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            radius--;
            if (radius < 0) radius = 0;
        }
        if (Input.GetMouseButton(0)) {
            Vector3Int tileToSet = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            states[currentState].SetCells(tileToSet,tilemap,tile, mode, radius);
        }
    }
}
