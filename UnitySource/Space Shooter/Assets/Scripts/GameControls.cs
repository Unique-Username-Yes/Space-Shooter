using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControls : MonoBehaviour
{
    public static GameControls instance;

    public Scene thisScene;
    public bool isPlayerDead = false;

    public static int mainSceneIndex = 1;
    public static int endSceneIndex = 2;

    private void Awake()
    {
        if (!instance)
            instance = this;

        DontDestroyOnLoad(gameObject);

        ResetGame();
    }
    // Update is called once per frame
    void Update()
    {
        // TODO: Pause game

        // TODO: Display pause screen

        if (Input.GetKeyDown(KeyCode.R))
            ResetGame();
        if (Input.GetKeyDown(KeyCode.Escape))
            TerminateGame();

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            PlayerProgression.instance.LevelUp();
        }

        if (Input.GetKeyDown(KeyCode.Period))
        {
            Debug.Log("Pressed");
            PlayerProgression.instance.GiveUpgradePoints(5);
        }
    }

    public void EndScreen()
    {
        SceneManager.LoadScene(endSceneIndex);
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(mainSceneIndex);
    }

    private void TerminateGame()
    {
        Application.Quit();
    }
}
