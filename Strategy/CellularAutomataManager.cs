using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
public class CellularAutomataManager : MonoBehaviour {
    int sizeX = 10;
    int sizeY = 10;
    int xOffset = 5;
    int yOffset = 5;
    int[,] map;

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Tilemap borderTilemap;
    [SerializeField] private TileBase tile;

    [SerializeField] private TextMeshProUGUI fillProcentText;
    [SerializeField] private TextMeshProUGUI timeScallerText;
    [SerializeField] private float timeMinimum;
    [SerializeField] private float timeMaximum;
    [SerializeField] private Image[] buttonsImages;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color clickedColor;
    private float timeScaller;
    private float fillProcent;
    private int currentStrategyID = 0;
    private AutomataStrategy[] strategies;
    private bool isPaused = true;

    void Start() {
        tilemap = this.GetComponent<Tilemap>();
        strategies = new AutomataStrategy[3];
        strategies[0] = new GameOfLifeAutomata();
        strategies[1] = new Rule942Automata();
        strategies[2] = new CaveGenerationAutomata();
    }
    public void AdjustFillProcent(float newProcent) {
        fillProcent = (float)Math.Round(newProcent * 100, 0);
        fillProcentText.text = fillProcent.ToString() + "%";
    }

    public void AdjustTimeScallar(float newProcent) {
        timeScaller = (float)Math.Round(newProcent, 2);
        if (timeScaller == 0) timeScaller = 0.01f;
        timeScallerText.text = timeScaller.ToString()+"s";
        timeSample = timeScaller;
    }

    public void SetPause() {
        isPaused = !isPaused;
    }


    public void ConstructMap(int sizeX, int sizeY) {
        this.sizeX = sizeX;
        this.sizeY = sizeY;
        map = new int[sizeX, sizeY];
        xOffset = this.sizeX / 2;
        yOffset = this.sizeY / 2;
        for (int y = -yOffset - 1; y <= yOffset; y++) {
            for (int x = -xOffset - 1; x <= xOffset; x++) {
                if (x == -xOffset - 1 || x == xOffset || y == -yOffset - 1 || y == yOffset) {
                    borderTilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }
        borderTilemap.RefreshAllTiles();
    }

    float elapsedTime = 0f;
    float timeSample = 1f;
    private void Update() {
        if (map != null) { 
            if(!isPaused)
            UpdateEveryX();
            SetCell();
        }
    }

    private void SetCell() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        }
        if (Input.GetMouseButton(0)) {
            
            Vector3Int tileToSet = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (!IsPositionInsideMap(tileToSet)) return;
            map[tileToSet.x+ xOffset, tileToSet.y+ yOffset] = 1;
            tilemap.SetTile(tileToSet, tile);
            tilemap.RefreshTile(tileToSet);
        }
        if (Input.GetMouseButton(1)) {
            Vector3Int tileToSet = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (!IsPositionInsideMap(tileToSet)) return;
            map[tileToSet.x + xOffset, tileToSet.y + yOffset] = 0;
            tilemap.SetTile(tileToSet, null);
            tilemap.RefreshTile(tileToSet);
        }
    }



    private bool IsPositionInsideMap(Vector3Int pos) {
        if (pos.x < -xOffset || pos.x >= xOffset || pos.y < -yOffset || pos.y >= yOffset) return false;
        return true;

    }

    private void UpdateEveryX() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeSample) {
            elapsedTime = elapsedTime % timeSample;
            IterateAutomata();
        }
    }

    public void IterateAutomata() {
        map = strategies[currentStrategyID].Iterate(map);
        DrawMap();
    }

    private void DrawMap() {
        tilemap.ClearAllTiles();
        for (int y = -yOffset; y < yOffset; y++) {
            for (int x = -xOffset; x < xOffset; x++) {
                if (map[x + xOffset, y + yOffset] != 0) {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }
        tilemap.RefreshAllTiles();
    }

    public void RandomFill() {
        for (int x = 0; x < sizeX; x++) {
            for (int y = 0; y < sizeY; y++) {
                map[x, y] = 0;
                if (Random.Range(0, 100) > fillProcent) {
                    map[x, y] = 0;
                }
                else map[x, y] = 1;
            }
        }
        DrawMap();
    }

    public void SetStrategy(int ID) {
        currentStrategyID = ID;
        foreach (Image i in buttonsImages)
            i.color = normalColor;
        buttonsImages[ID].color = clickedColor;
    }
}
