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
    void Update()
    {
        if (inAir == true)
        {
            canDrop = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop)
        {

            
            
            inAir = false;
            canDrop = false;
            GetComponent<Rigidbody2D>().gravityScale = 3;

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            manager.movementFruit.position = new Vector2(mousePosition.x, manager.movementFruit.position.y);


            GameManager.canSpawn = true;
           
            



        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            GameManager.spawnPos = transform.position;
            GameManager.mergeFruit = true;
            GameManager.whichFruit = int.Parse(gameObject.tag);
            Destroy(gameObject);
            
        }
    }

   
}
