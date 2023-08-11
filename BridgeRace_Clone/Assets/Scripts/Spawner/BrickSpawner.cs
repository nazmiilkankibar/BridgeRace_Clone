using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] bricks = new GameObject[3];
    private List<Transform> spawnPositions = new List<Transform>();
    [SerializeField] private Transform child;
    private void Start()
    {
        child = transform.GetChild(0);
        AddSpawnPositionsToList();
        SpawnStartBricks();
    }
    private void SpawnStartBricks()
    {
        for (int i = 0; i < spawnPositions.Count; i++)
        {
            GameObject brick = Instantiate(bricks[Random.Range(0, 3)],spawnPositions[i].position,spawnPositions[i].rotation,spawnPositions[i]);
            brick.SetActive(true);
        }
    }
    private void AddSpawnPositionsToList()
    {
        for (int i = 0; i < child.childCount; i++)
        {
            spawnPositions.Add(child.GetChild(i).transform);
        }
    }
}
