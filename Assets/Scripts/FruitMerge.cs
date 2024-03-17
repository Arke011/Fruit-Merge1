using System.Collections;
using UnityEngine;

public class FruitMerge : MonoBehaviour
{
    
    public GameManager manager;
    


    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    

    



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == gameObject.tag)
        {
            
            GameManager.totalCollisions += 1;

            if (GameManager.totalCollisions < 3)
            {
                GameManager.spawnPos = transform.position;
                GameManager.mergeFruit = true;
                GameManager.whichFruit = int.Parse(gameObject.tag);
                Destroy(gameObject);
            }
            
            
            
        }
    }

   
}
