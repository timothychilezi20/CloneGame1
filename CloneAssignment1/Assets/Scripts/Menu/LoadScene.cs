using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;//name of the scene 
    public GameObject controlsOptions;
    public GameObject pauseOptions;
    public GameObject gameOverCanvas;
    private PlayerHealth playerHP;
    public void changeScene()//change to the specified scene
    {
        SceneManager.LoadScene(sceneName);
    }

    public void endGame()//end the game
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void openControls()//open the controls panel
    {
        controlsOptions.SetActive(true);
    }

    public void closeControls()//close control panel
    {
        controlsOptions.SetActive(false);
    }

    public void pauseGame()//pause the game
    {
        Time.timeScale = 0f;//pause game
        pauseOptions.SetActive(true);//open pause menu
    }

    public void resumeGame()
    {
        pauseOptions.SetActive(false);//open pause menu
        Time.timeScale = 1f;//pause game
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //public void gameOver()
    //{
    //    if (playerHP.currentLives == 0)
    //    {
    //        Debug.Log("Trigger Game Over!");
    //        gameOverCanvas.SetActive(true);
    //    }
    //}
}
