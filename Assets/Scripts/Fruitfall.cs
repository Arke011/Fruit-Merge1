using UnityEngine;

public class Fruitfall : MonoBehaviour
{

    Fruit fruit;

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision detected");

        if (fruit != null)
        {
            fruit.canSpawnFruit = true;
            Debug.Log("canSpawnFruit set to true");
        }
        else
        {
            Debug.Log("fruitManager is null");
        }
    }

}
