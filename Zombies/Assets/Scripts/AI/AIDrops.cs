using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDrops : MonoBehaviour
{
    [SerializeField] Drop[] dropList;
    private void SpawnDrop()
    {
        int drop = Random.Range(0, 2);
        Drop selected = null;
        switch (drop)
        {
            case 0:
                selected = dropList[0];
                break;
            case 1:
                selected = dropList[1];
                break;
            default:
                break;
        }
        Vector3 position = transform.position;
        position.y += 1;

        Instantiate(selected, position, Quaternion.identity);
    }

    public void CheckDrop()
    {
        int value = Random.Range(1, 30);

        if (value == 12)
        {
            SpawnDrop();
        }
    }
}
