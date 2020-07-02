using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    

    [SerializeField]
    GameObject pausePanel;

    void Start()
    {

        pausePanel.SetActive(false);


    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ReStart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScoreScript.score = 0 ;
        Time.timeScale = 1f;

    }

    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void LoadGameScene()
    {
        ScoreScript.score = 0;
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
