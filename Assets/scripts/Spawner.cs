using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] public Character prefabToSpawn;
    [SerializeField] private Transform enemyTarget;

    [SerializeField] private bool isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(enemyTarget.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnPrefab();
        } else if (Input.GetKeyDown(KeyCode.Z))
        {
            SpawnPrefab();
        }
    }

    

    void SpawnPrefab()
    {
            Character c1s = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            c1s.SetTarget(enemyTarget);
            c1s.camp = isPlayer ? "Player" : "Enemy";
    }
}