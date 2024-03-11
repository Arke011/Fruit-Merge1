using System.Collections;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject[] fruits;
    public int fruitSpawnY = 0;
    
    public bool canSpawnFruit = true;
    public bool mergeFruit = false;
    public FruitMerge merge;
    public static int whichFruit = 0;
    public static Vector2 destroyPos;


    void SpawnRandomFruit()
    {
        
        Vector2 spawnPos = new Vector2(0f, 4f);

        Instantiate(fruits[Random.Range(0, 3)], spawnPos, Quaternion.identity);

        

        canSpawnFruit = false;
    }

    void Update()
    {
        MergeFruit();

        if (canSpawnFruit)
        {
            SpawnRandomFruit();
        }
    }

    void Start()
    {
        merge = FindObjectOfType<FruitMerge>();
        Application.targetFrameRate = 30;
    }

    public void MergeFruit()
    {
        if (mergeFruit == true)
        {
            mergeFruit = false;
            Instantiate(fruits[whichFruit], destroyPos, Quaternion.identity);


        }
    }

    

}
