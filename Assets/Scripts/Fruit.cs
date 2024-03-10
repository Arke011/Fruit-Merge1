using System.Collections;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject[] fruits;
    public int fruitSpawnY = 0;
    public int fruitToSpawn = 0;
    public bool canSpawnFruit = true;

    void SpawnRandomFruit()
    {
        
        Vector2 spawnPos = new Vector2(0f, 4f);

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
