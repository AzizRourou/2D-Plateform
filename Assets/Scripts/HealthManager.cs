using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        
    }

    void Die()
    {
        GetComponent<Animator>().SetBool("Dead", true);
        GetComponent<CharacterController2D>().enabled = false;
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
    }
}
