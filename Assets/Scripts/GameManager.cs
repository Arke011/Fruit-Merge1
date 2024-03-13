using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform[] fruits;
    static public bool canSpawn = true;
    static public Vector2 spawnPos;
    static public bool mergeFruit = false;
    static public int whichFruit;
    public Transform movementFruit;
    public Transform mergedFruit;
    public AudioClip mergeSound;
    public AudioClip spawnSound;
    public GameObject mergeEffect;
    public TMP_Text scoreTXT;
    public int score = 0;
    public GameObject gameStartScreen;
    public GameObject youWonScreen;
    public GameObject YouLostScreen;
    public TMP_Text youScoredTXT1;
    public TMP_Text scoredTXT;







    void Start()
    {

    }

    void Update()
    {
        spawnFruit();
        mergeFruits();
        Win();
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameStartScreen.SetActive(false);
        }

        
        
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
            Instantiate(mergeEffect, mergedFruit.position, mergedFruit.rotation);
            AudioSystem.Play(mergeSound);
            score += 10;
            scoreTXT.text = score.ToString();

            
            Rigidbody2D mergedFruitRb = mergedFruit.GetComponent<Rigidbody2D>();

            if (mergedFruitRb != null)
            {
                
                mergedFruitRb.gravityScale = 3f;
            }
            else
            {
                Debug.LogWarning("mergedFruit doesn't have a Rigidbody2D component.");
            }
        }
    }


    public IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(0.75f);
        movementFruit = Instantiate(fruits[Random.Range(0, 4)], transform.position, fruits[0].rotation);
        AudioSystem.Play(spawnSound);
    }

    void Win()
    {
        if (whichFruit >= 8)
        {
            Debug.Log("You just won");
            youWonScreen.SetActive(true);
            youScoredTXT1.text = "you scored: " + score.ToString();
            Invoke("ReloadScene", 5f);

        }
    }

    


    void ReloadScene()
    {
        SceneManager.LoadScene("Fruits");
    }
}
