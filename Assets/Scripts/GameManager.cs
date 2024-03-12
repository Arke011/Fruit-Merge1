using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] fruits;
    static public bool canSpawn = true;
    static public Vector2 spawnPos;
    static public bool mergeFruit = false;
    static public int whichFruit;

    void Start()
    {

    }

    void Update()
    {
        spawnFruit();
        mergeFruits();
    }

    void spawnFruit()
    {
        if (canSpawn == true)
        {
            StartCoroutine(spawnTimer());
            canSpawn = false;
        }
    }

    void mergeFruits()
    {
        if (mergeFruit == true)
        {
            mergeFruit = false;
            Instantiate(fruits[whichFruit + 1], spawnPos, fruits[0].rotation);
        }
    }

    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(0.75f);
        Instantiate(fruits[Random.Range(0, 4)], transform.position, fruits[0].rotation);
        
    }
}
