using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneName;//name of the scene 
    public GameObject controlsOptions;
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
}
