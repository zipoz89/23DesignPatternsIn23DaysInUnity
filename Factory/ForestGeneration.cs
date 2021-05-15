using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGeneration : ChunkOnPlaneGenerator {
    Queue<GameObject> generatedChunks = new Queue<GameObject>();
    [SerializeField] private int gridX = 10;
    [SerializeField] private int gridY = 10;
    [SerializeField] private Vector3 centrPosition = new Vector3(0,0,0);
    [SerializeField] private float planeSize = 100;
    [SerializeField] private int countOnEachSideFromCenter = 1;
    [SerializeField] private GameObject[] chunkPrefabs;
    [SerializeField] private float spawnFromZ = 0;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float destroyAndspawnAfterX = 100;
    [SerializeField] private int chunkidtoSpawn = 0;

    void Start() {
        SpawnStartingChunks();
    }

    public override void SpawnStartingChunks() {
        for (int i = -countOnEachSideFromCenter; i <= countOnEachSideFromCenter; i++) {
            Vector3 spawnPos = new Vector3(centrPosition.x - i * planeSize, centrPosition.y, centrPosition.z);
            SpawnNew(spawnPos);
            //Debug.Log(spawnPos);
        }
    }

    public override void SpawnNew(Vector3 spawnPos) {
        GameObject o = Instantiate(chunkPrefabs[chunkidtoSpawn]);
        o.transform.position = spawnPos;
        o.transform.parent = this.transform;
        o.GetComponent<ChunkOnPlane>().GenerateChunk(spawnPos, planeSize,spawnFromZ, gridX, gridY);
        generatedChunks.Enqueue(o);
    }


    void Update()
    {
        foreach (GameObject o in generatedChunks) {
            o.transform.position = new Vector3(o.transform.position.x + Time.deltaTime * moveSpeed, o.transform.position.y, o.transform.position.z);  
        }
        if (generatedChunks.Peek().transform.position.x > destroyAndspawnAfterX+(planeSize/2)) {
            Destroy(generatedChunks.Peek());
            generatedChunks.Dequeue();
            SpawnNew(new Vector3(centrPosition.x - destroyAndspawnAfterX-(planeSize / 2), centrPosition.y, centrPosition.z));
        }
    }
}
