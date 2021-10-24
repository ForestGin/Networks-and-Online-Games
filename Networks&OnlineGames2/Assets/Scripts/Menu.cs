using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void ChangeToScene(string sceneName)
    {
        Debug.Log("Changing to " + sceneName + "Scene");
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Debug.Log("Exitting Game...");
        Application.Quit();
    }
}
