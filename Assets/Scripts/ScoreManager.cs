using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    int score;
    int levelScore = 0;
    public Text scoreText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            score++;
            levelScore++;
            PlayerPrefs.SetInt("savedscore", score);
            Destroy(collision.gameObject);
            scoreText.text = score.ToString();
        }
    }

    private void Start()
    {
        score = PlayerPrefs.GetInt("savedscore");
        scoreText.text = score.ToString();
    }

    void Update()
    {
        
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

        //if 10coins collected go to next level
        if (levelScore > 9)
        {
            StartCoroutine("NextLevel");
            levelScore = 0;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log("levelScore is " + levelScore);
        Debug.Log("score is " + score);
        Debug.Log("savedscore is " + PlayerPrefs.GetInt("savedscore"));
        Debug.Log("Highscore is " + PlayerPrefs.GetInt("Highscore"));
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
