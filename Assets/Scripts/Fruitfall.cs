using UnityEngine;
using System.Collections;

public class Fruitfall : MonoBehaviour
{
    public Fruit fruit; 

    void Start()
    {
       
        fruit = FindObjectOfType<Fruit>();

        if (fruit == null)
        {
            Debug.LogError("Fruit script not found on GameManager GameObject!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 spawnPos = new Vector3(mousePosition.x, 4f, 0f);
            transform.position = spawnPos;
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
       

        if (fruit != null)
        {
            fruit.canSpawnFruit = true;
            Destroy(this);
        }
        
    }

    
}
