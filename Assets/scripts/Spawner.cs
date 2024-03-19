using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public Character m_prefabToSpawn;
    [SerializeField] private Transform enemyTarget;

    [SerializeField] private bool isPlayer;

    void Start()
    {
        //Debug.Log(enemyTarget.name);
    }

    // trigger createcharacter on input
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SpawnPrefab(isPlayer);
        }
    }

    
    // Create new character with tag, target and position
    void SpawnPrefab(bool isPlayer)
    {
            Character newAgent = Instantiate(m_prefabToSpawn, transform.position, Quaternion.identity);
            newAgent.m_targetBase = enemyTarget;
            newAgent.tag = isPlayer ? "Player" : "Enemy";
            
    }
}