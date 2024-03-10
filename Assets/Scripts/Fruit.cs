using System.Collections;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject[] fruits;
    public int fruitSpawnY = 4;
    private bool isFruitFalling = false;
    public bool canSpawnFruit = true;

    void SpawnRandomFruit()
    {
        if (!isFruitFalling)
            return;

        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector3 spawnPosition = new Vector3(mousePosition.x, fruitSpawnY, 0f);

        int randomIndex = Random.Range(0, fruits.Length);
        GameObject newFruit = Instantiate(fruits[randomIndex], spawnPosition, Quaternion.identity);
        isFruitFalling = false;
        canSpawnFruit = false;
    }

    void Update()
    {
        SpawnRandomFruit();

        if (Input.GetKeyDown(KeyCode.Mouse0) && canSpawnFruit)
        {
            StartFruitFall();
        }
    }

    
    public void StartFruitFall()
    {
        isFruitFalling = true;
    }
}
