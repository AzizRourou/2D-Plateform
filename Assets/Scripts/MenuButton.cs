using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("savedscore", 0);
        PlayerPrefs.SetInt("Highscore", 0);
    }

    public static void Start()
    {
        SceneManager.LoadScene(1);
    }
}
