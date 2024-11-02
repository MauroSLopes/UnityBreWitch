using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerbSpawner : MonoBehaviour
{
    float spawnRangeWidth = 10f;
    float spawnRangeHeight = 5f;

    public GameObject[] herbsArray = new GameObject[5];
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    public IEnumerator SpawnCoroutine()
    {
        while (true) { 
        yield return new WaitForSeconds(Random.Range(1f, 7f));
        Vector3 spawnLocation = new Vector3(Random.Range(-spawnRangeWidth, spawnRangeWidth), 
            Random.Range(-spawnRangeHeight, spawnRangeHeight), 0f);
        Instantiate(herbsArray[Random.Range(0, herbsArray.Length)], spawnLocation, Quaternion.identity);
        }
    }
}
