using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//load scenes
public class GameManager : MonoBehaviour
{
    public bool gameHasStarted;
    public float timeStarted;
    public GameObject startMenu;
    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        gameHasStarted = true;
        timeStarted = Time.timeSinceLevelLoad;
        startMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("You quit the game.");
        Application.Quit();
    }
}
