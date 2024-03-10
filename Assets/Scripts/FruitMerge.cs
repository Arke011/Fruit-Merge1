using System.Collections;
using UnityEngine;

public class FruitMerge : MonoBehaviour
{
    public GameObject[] mergedFruits;  // Specify the GameObjects to be instantiated upon merging

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("blueberry"))
        {
            MergeFruits(collision.collider.gameObject);
        }
    }

    void MergeFruits(GameObject selectedFruit)
    {
        // Check if both the current fruit and the selected fruit have the tag "blueberry"
        if (gameObject.CompareTag("blueberry") && selectedFruit.CompareTag("blueberry"))
        {
            // Destroy the colliding fruits
            Destroy(selectedFruit.gameObject);
            Destroy(gameObject);

            // Instantiate a specified GameObject upon merging
            int randomIndex = Random.Range(0, mergedFruits.Length);
            GameObject newMergedFruit = Instantiate(mergedFruits[randomIndex], transform.position, Quaternion.identity);
        }
    }
}

