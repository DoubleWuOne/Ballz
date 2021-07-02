using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] private Block blockPrefab;
    [SerializeField] private Block specialBlockPrefab;
    private float distanceBetwenBlocks = 0.55f;
    private int playWidth = 10;
    private int rowsSpawn;
    private List<Block> blockSpawned = new List<Block>();
    private void OnEnable()
    {
        for (int i = 0; i < 1; i++)
        {
            SpawnRowOfBlocks();
        }
    }

    public void SpawnRowOfBlocks()
    {
        foreach (var block in blockSpawned)
        {
            if (block != null) // nie przesuwac zniszczone bloki przypadkiem
            {
                block.transform.position += Vector3.down * distanceBetwenBlocks;
            }
        }
        for (int i = 0; i < playWidth; i++)
        {
            if (UnityEngine.Random.Range(0, 100) < 50)
            {
                if (UnityEngine.Random.Range(0, 10) < 1)
                {
                    var block2 = Instantiate(specialBlockPrefab, GetPosition(i), Quaternion.identity);
                    block2.SetHits(1);
                    block2.special = true;
                    block2.spriteRender.color = Color.green;
                    blockSpawned.Add(block2);
                }
                else
                {
                    var block = Instantiate(blockPrefab, GetPosition(i), Quaternion.identity);
                    int hits = UnityEngine.Random.Range(1, 3) + rowsSpawn;

                    block.SetHits(hits);
                    block.special = false;
                    blockSpawned.Add(block);
                }
            }
        }
        rowsSpawn++;
    }

    private Vector3 GetPosition(int i)
    {
        Vector3 position = transform.position;
        position += Vector3.right * i * distanceBetwenBlocks;
        return position;

    }
}
