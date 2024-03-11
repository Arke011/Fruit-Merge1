using System.Collections;
using UnityEngine;

public class FruitMerge : MonoBehaviour
{
    public Fruitfall fall;
    public Fruit fruit;
    private bool hasMerged = false;
    private Vector2 destroyPos;
    

    void Start()
    {
        fall = FindObjectOfType<Fruitfall>();
        fruit = FindObjectOfType<Fruit>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag && !fruit.mergeFruit)
        {
            Fruit.destroyPos = transform.position;
            fruit.mergeFruit = true;
            Fruit.whichFruit = int.Parse(gameObject.tag);
            
            Destroy(gameObject);
            
        }
    }

    


}
