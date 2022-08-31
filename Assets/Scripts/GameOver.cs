using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public ChangeNumber changeNumber;
    public GameObject GameOverPanel;

    private void Start()
    {
        GameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        GameIsOver();
    }

    void GameIsOver()
    {
        if(changeNumber.isGameOver)
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
