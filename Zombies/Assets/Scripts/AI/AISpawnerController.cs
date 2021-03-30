using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawnerController : MonoBehaviour
{
    public int totalEnemies;
    public Transform target;
    public Transform enemyParent;

    public bool SpawnEnemies(AISpawner spawner)
    {
        if(totalEnemies > 0)
        {
            spawner.SpawnAI(enemyParent);
            totalEnemies--;
            if(totalEnemies > 0)
            {
                return true;
            }
        }
        return false;
    }
}
