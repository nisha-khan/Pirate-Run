using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         AudioManager.instance.Play("Finish");
        // Get the Rigidbody2D component from the player GameObject.
            rb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Check if the Rigidbody2D component was found.
            if (rb != null)
            {
                UnlockNewLevel();
                // Set the Rigidbody2D to Static.
                rb.bodyType = RigidbodyType2D.Static;

                // Play the "Finish" audio.
        

                // Activate the LevelCompletePanel.
                PlayerManager.isGameComplete = true;
            }
            
    }

    void UnlockNewLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex>=PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex",SceneManager.GetActiveScene().buildIndex+1);
            PlayerPrefs.SetInt("UnlockedLevel",PlayerPrefs.GetInt("UnlockedLevel",1) +1);
            PlayerPrefs.Save();
            
        }
    }
}
