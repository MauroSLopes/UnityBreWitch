using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemysArray;

    [SerializeField] Vector2 minSpawn, maxSpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTime());
    }

    IEnumerator SpawnTime()
    {
        while (true)
        {
            float interval = Random.Range(1f, 3f);
            GameObject enemy = enemysArray[Random.Range(0, enemysArray.Length)];

            yield return new WaitForSeconds(interval);
            Vector3 spawnPoint = Vector3.zero;
            bool isVerticalSpawn = Random.Range(0f, 1f) > .5f;

            if (isVerticalSpawn)
            {
                spawnPoint.y = Random.Range(minSpawn.y, maxSpawn.y);

                if (Random.Range(0f, 1f) > .5f)
                {
                    spawnPoint.x = minSpawn.x;
                }
                else
                {
                    spawnPoint.x = maxSpawn.x;
                }
            }
            else
            {
                spawnPoint.x = Random.Range(minSpawn.x, maxSpawn.x);

                if (Random.Range(0f, 1f) > .5f)
                {
                    spawnPoint.y = minSpawn.y;
                }
                else
                {
                    spawnPoint.y = maxSpawn.y;
                }
            }

            Instantiate(enemy, spawnPoint, Quaternion.identity);
        }
    }
}
