using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] bricks = new GameObject[3];
    private List<Transform> spawnPositions = new List<Transform>();
    [SerializeField] private Transform child;
    [SerializeField] private float spawnRate;
    private float spawnTime;
    private void Start()
    {
        child = transform.GetChild(0);
        AddSpawnPositionsToList();
        SpawnStartBricks();
    }
    private void Update()
    {
        if (spawnTime <= 0)
        {
            for (int i = 0; i < spawnPositions.Count; i++)
            {
                if (spawnPositions[i].childCount == 0)
                {
                    SpawnBrick(spawnPositions[i]);
                    spawnTime = spawnRate;
                    break;
                }
            }
            
            spawnTime = spawnRate;
        }
        else
        {
            spawnTime -= Time.deltaTime;
        }
    }
    private void SpawnStartBricks()
    {
        for (int i = 0; i < spawnPositions.Count; i++)
        {
            SpawnBrick(spawnPositions[i]);
        }
    }
    private void AddSpawnPositionsToList()
    {
        for (int i = 0; i < child.childCount; i++)
        {
            spawnPositions.Add(child.GetChild(i).transform);
        }
    }
    private void SpawnBrick(Transform target)
    {
        GameObject brick = Instantiate(bricks[Random.Range(0, 3)], target.position, target.rotation, target);
        brick.SetActive(true);
    }
}
