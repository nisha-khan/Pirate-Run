using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    
    [SerializeField] GameObject pauseMenu;
    private Animator anim;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HealthManager.health--; // Access the static variable directly
            if (HealthManager.health <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("deathTrigger");
        AudioManager.instance.Play("GameOver");
        PlayerManager.isGameOver= true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadSceneByBuildIndex(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
    }

    

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(7, 8);
        GetComponent<Animator>().SetLayerWeight(1,1);
        yield return new WaitForSeconds(3);
          GetComponent<Animator>().SetLayerWeight(1,0);
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

}
