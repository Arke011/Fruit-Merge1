using System.Collections;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject[] fruits;
    public int fruitSpawnY = 0;
    private int fruitToSpawn = 0;
    public bool canSpawnFruit = true;

    void SpawnRandomFruit()
    {
        
        Vector3 spawnPos = new Vector3(0f, 4f, 0f);

        Instantiate(fruits[fruitToSpawn], spawnPos, Quaternion.identity);

        if (fruitToSpawn >= 3)
        {
            fruitToSpawn = 0;
        }
        else
        {
            fruitToSpawn++;
        }

        canSpawnFruit = false;
    }

    void Update()
    {
        if (canSpawnFruit)
        {
            SpawnRandomFruit();
        }
    }
}
