using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public Character m_prefabLow;
    [SerializeField] public Character m_prefabMedium;
    [SerializeField] public Character m_prefabHigh;
    [SerializeField] private Transform enemyTarget;

    [SerializeField] private bool isPlayer;

    void Start()
    {
        //Debug.Log(enemyTarget.name);
    }

    // trigger createcharacter on input
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnPrefab(isPlayer, "low", m_prefabLow);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            SpawnPrefab(isPlayer, "moderate", m_prefabMedium);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnPrefab(isPlayer, "high", m_prefabHigh);
        }
    }

    
    // Create new character with tag, target and position
    void SpawnPrefab(bool isPlayer, string type, Character characterType)
    {
        Character newAgent = Instantiate(characterType, transform.position, Quaternion.identity);
        newAgent.m_targetBase = enemyTarget;
        newAgent.tag = isPlayer ? "Player" : "Enemy";
        if (type == "low")
        {
            newAgent.hp = 20;
            newAgent.damagePerSecond = 5;
        }
        else if (type == "moderate")
        {
            newAgent.hp = 30;
            newAgent.damagePerSecond = 10;
        }
        else if (type == "high")
        {
            newAgent.hp = 40;
            newAgent.damagePerSecond = 15;
        }
    }
}