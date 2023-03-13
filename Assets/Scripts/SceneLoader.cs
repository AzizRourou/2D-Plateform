using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static void Restart()
    {
        PlayerPrefs.SetInt("savedscore", 0);
        SceneManager.LoadScene(1);
    }

    public static void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
