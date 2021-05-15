using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChunkOnPlane : MonoBehaviour {
    public abstract void GenerateChunk(Vector3 spawnPos, float planeSize, float spawnFormZ, int gridX, int gridY);
}

public abstract class ChunkOnPlaneGenerator : MonoBehaviour {
    public abstract void SpawnStartingChunks();
    public abstract void SpawnNew(Vector3 spawnPos);
}