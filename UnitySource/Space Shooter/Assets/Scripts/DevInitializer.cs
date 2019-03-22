using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevInitializer : MonoBehaviour
{
    private void Awake()
    {
        if (!GameObject.Find("__Global"))
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
