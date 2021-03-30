using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay = 5f;
    [SerializeField] EnemyAI spawn;
    AISpawnerController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = FindObjectOfType<AISpawnerController>();
        StartCoroutine(SpawnDelay());
    }
    public void SpawnAI(Transform parent)
    {
        EnemyAI ai = Instantiate(spawn, transform.position, Quaternion.identity);
        ai.target = controller.target;
        ai.transform.SetParent(parent);
    }

    IEnumerator SpawnDelay()
    {
        while(controller.SpawnEnemies(this))
        {
            yield return new WaitForSeconds(spawnDelay);
        }       
    }
}
