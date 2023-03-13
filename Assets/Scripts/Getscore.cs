using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Getscore : MonoBehaviour
{
    public Text score;
    public Text highscore;

    void Update()
    {
        score.text = PlayerPrefs.GetInt("savedscore").ToString();
        highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
}
