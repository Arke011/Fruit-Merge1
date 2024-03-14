using System.Collections;
using UnityEngine;

public class FruitMerge : MonoBehaviour
{
    private bool inAir = true;
    
    private bool canDrop = false;
    public GameManager manager;
    


    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    async void Update()
    {
        if (inAir == true)
        {
            canDrop = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop)
        {       
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePosition.x < -2.9 || mousePosition.x > 2.8) return;

            inAir = false;
            canDrop = false;
            GetComponent<Rigidbody2D>().gravityScale = 3;

            if (manager.movementFruit != null)
            {
                manager.movementFruit.position = new Vector2(mousePosition.x, manager.movementFruit.position.y);
            }

            await new WaitForSeconds(1f);
            
            GameManager.canSpawn = true;
        }
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
