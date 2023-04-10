using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private const float PLAY_DISTANCE_SPAWN_LEVEL_PART = 150f;

    public Transform levelPart_Start;
    public List<Transform> levelPartList;
    public PlayerController player;

    private Vector3 lastEndPosition;


    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        
        int startingSpawnLevelParts = 2;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.GetPosition(), lastEndPosition) < PLAY_DISTANCE_SPAWN_LEVEL_PART)
        {          
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
