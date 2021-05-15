using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestChunkWithCottage : ChunkOnPlane {
    [SerializeField] private GameObject[] trees;
    [SerializeField] private GameObject cottagePref;
    [SerializeField] private float gladeSize = 10;
    [SerializeField] private float cottagexOffset = 0;
    public override void GenerateChunk(Vector3 spawnPos, float planeSize, float spawnFormZ, int gridX, int gridY) {
        float xSample = planeSize / gridX;
        float ySample = planeSize / gridY;
        Debug.Log(planeSize / 4);
        float cSpawnX = Random.Range(spawnPos.x- planeSize/4, spawnPos.x + planeSize / 4);
        float cSpawnZ= Random.Range(spawnPos.z - planeSize / 4, spawnPos.z + planeSize / 4);
        GameObject cottage = Instantiate(cottagePref);
        Vector3 cottageSpawnPoint = new Vector3(cSpawnX, 0f, cSpawnZ);
        cottage.transform.position = new Vector3(cSpawnX + cottagexOffset, 0f, cSpawnZ);
        cottage.transform.parent = this.transform;


        for (int y = 0; y < gridY; y++) {
            for (int x = 0; x < gridX; x++) {

                float spawnZ = Random.Range(y * ySample, y * ySample + ySample) + spawnPos.z - planeSize / 2;
                if (spawnZ < spawnFormZ) 
                    break;
                float spawnX = Random.Range(x * xSample, x * xSample + xSample) + spawnPos.x - planeSize / 2;
                Vector3 spawnPosOfTree = new Vector3(spawnX, 7.5f, spawnZ);
                if (Vector2.Distance(new Vector2(spawnPosOfTree.x, spawnPosOfTree.z), new Vector2(cottageSpawnPoint.x, cottageSpawnPoint.z)) < gladeSize) 
                    break;
                GameObject o = Instantiate(trees[(int)Random.Range(0, trees.Length)]);
                o.transform.position = spawnPosOfTree;
                o.transform.parent = this.transform;
            }
        }
    }


}
