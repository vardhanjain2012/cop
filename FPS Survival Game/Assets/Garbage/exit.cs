using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    public void Restartgame()
    {
        SceneManager.LoadScene(1);
    }
    public void Tomenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quitgame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
