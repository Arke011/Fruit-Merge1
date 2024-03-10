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
        if (!hasMerged && collision.gameObject.tag == gameObject.tag)
        {
            destroyPos = transform.position;
            Debug.Log("Merging at position: " + destroyPos);
            StartCoroutine(MergeFruitCoroutine());
            Destroy(gameObject);
            hasMerged = true;
        }
    }

    IEnumerator MergeFruitCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Spawning merged fruit at position: " + destroyPos);
        Instantiate(fruit.fruits[fruit.fruitToSpawn + 1], destroyPos, Quaternion.identity);
    }
}
