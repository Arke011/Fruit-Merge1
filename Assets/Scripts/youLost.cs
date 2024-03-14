using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class youLost : MonoBehaviour
{
    
    public GameManager manager;


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.CompareTag("Ground") && transform.position.y > 1f)
        {
            Debug.Log("You just lost");
            manager.YouLostScreen.SetActive(true);
            manager.scoredTXT.text = "You scored: " + manager.score.ToString();
            Invoke("ReloadScene", 5f);
        }
    }


    void Start()
    {
        
        manager = FindObjectOfType<GameManager>();
        




        if (manager == null)
        {
            Debug.LogError("GameManager not found in the scene.");
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene("Fruits");
    }
}
