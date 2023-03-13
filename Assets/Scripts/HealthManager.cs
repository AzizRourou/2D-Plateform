using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    const float MAXHEALTH = 100f;
    float health;
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        health = MAXHEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -9.4)
        {
            this.Die();
        }
    }

    void Die()
    {
        GetComponent<Animator>().SetBool("Dead", true);
        GetComponent<CharacterController2D>().enabled = false;
        StartCoroutine("GameOverTransition");
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        //Debug.Log("damage");

        if (health <= 0)
        {
            health = 0;
            Die();
            //Debug.Log("dead");
        }
        if (health > MAXHEALTH)
        {
            health = MAXHEALTH;
        }

        healthSlider.value = health / MAXHEALTH;
        if (amount > 0)
        {
            GetComponent<AudioSource>().Play();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            Destroy(collision.gameObject);
            gameObject.tag = "PowerUp";
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            StartCoroutine("reset");
        }

    }
    IEnumerator reset()
    {
        yield return new WaitForSeconds(5f);
        gameObject.tag = "Player";
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    IEnumerator GameOverTransition()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(3);
    }
}
