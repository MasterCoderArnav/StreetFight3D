using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public GameObject enemyPrefab;
    public bool spawnEnemy;
    void Start()
    {
        spawnEnemy = true;
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnEnemy)
        {
            spawnEnemyInfiniteLoop();
        }
    }

    public void spawnEnemyInfiniteLoop()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        spawnEnemy = false;
    }
}
