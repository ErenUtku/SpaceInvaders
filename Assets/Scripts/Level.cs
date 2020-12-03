using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInsecond = 1.8f;
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
    SceneManager.LoadScene("LevelScene");
    }
    public void GameOver()
    {
        StartCoroutine(WaitAndLoad());
       
       
    }
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInsecond);
        SceneManager.LoadScene("GameOver");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
