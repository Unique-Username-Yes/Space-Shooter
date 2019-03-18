using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControls : MonoBehaviour
{
    public static GameControls instance;

    public bool isPlayerDead = false;

    private void Start()
    {
        if (!instance)
            instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        // TODO: Pause game

        // TODO: Display pause screen

        if (Input.GetKeyDown(KeyCode.R) && isPlayerDead)
            ResetGame();
        if (Input.GetKeyDown(KeyCode.Escape))
            TerminateGame();
    }

    private void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void TerminateGame()
    {
        Application.Quit();
    }
}
