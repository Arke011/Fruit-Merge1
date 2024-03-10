using System.Collections;
using UnityEngine;

public class FruitMerge : MonoBehaviour
{
    public Fruitfall fall;
    public Fruit fruit;


    void Start()
    {
        fall = FindObjectOfType<Fruitfall>();
        fruit = FindObjectOfType<Fruit>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            Vector2 destroyPos = transform.position; 
            Destroy(gameObject);
            Instantiate(fruit.fruits[fruit.fruitToSpawn + 1], destroyPos, Quaternion.identity);

        }
    }

    
}

