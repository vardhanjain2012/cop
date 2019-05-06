using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool IsPaused=false;

    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        } 
    }
        public void Resume()
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
            Cursor.visible = false;
        }
        void Paused()
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }
    public void LoadMenu()
    {
        Debug.Log("hhk");
        SceneManager.LoadScene(0);
    }
    public void QuitMenu()
    {
        Debug.Log("hh");
        Application.Quit();
    }
}
