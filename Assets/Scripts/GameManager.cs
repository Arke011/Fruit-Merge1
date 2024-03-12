using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] fruits;
    static public bool canSpawn = true;
    static public Vector2 spawnPos;
    static public bool mergeFruit = false;
    static public int whichFruit;
    public Transform movementFruit;
    public Transform mergedFruit;

    
    
    

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
        if (canSpawn)
        {
            StartCoroutine(spawnTimer());
            canSpawn = false;
        }
    }

    void mergeFruits()
    {
        if (mergeFruit)
        {
            mergeFruit = false;
            mergedFruit = Instantiate(fruits[whichFruit + 1], spawnPos, fruits[0].rotation);

            // Assuming mergedFruit has a Rigidbody2D component
            Rigidbody2D mergedFruitRb = mergedFruit.GetComponent<Rigidbody2D>();

            if (mergedFruitRb != null)
            {
                // Set the gravity scale to 3
                mergedFruitRb.gravityScale = 3f;
            }
            else
            {
                Debug.LogWarning("The mergedFruit object doesn't have a Rigidbody2D component.");
            }
        }
    }


    public IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(0.75f);
        movementFruit = Instantiate(fruits[Random.Range(0, 4)], transform.position, fruits[0].rotation);      
    }
}
