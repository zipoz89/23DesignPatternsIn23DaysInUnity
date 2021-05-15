using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ForestChunk : ChunkOnPlane
    {
    [SerializeField] private GameObject[] trees;


    public override void GenerateChunk(Vector3 spawnPos,float planeSize,float spawnFormZ,int gridX,int gridY) {
        float xSample = planeSize/gridX;
        float ySample = planeSize/gridY;
        for (int y = 0; y < gridY; y++) {
            for (int x = 0; x < gridX; x++) {
                
                float spawnZ = Random.Range(y * ySample, y * ySample + ySample) + spawnPos.z - planeSize / 2;
                if (spawnZ < spawnFormZ) break;
                GameObject o = Instantiate(trees[(int)Random.Range(0, trees.Length)]);
                float spawnX = Random.Range(x * xSample, x * xSample + xSample) + spawnPos.x - planeSize / 2;
                Vector3 spawnPosOfTree = new Vector3(spawnX, 7.5f,spawnZ);
                o.transform.position = spawnPosOfTree;
                o.transform.parent = this.transform;
            }
        }
    }


}
