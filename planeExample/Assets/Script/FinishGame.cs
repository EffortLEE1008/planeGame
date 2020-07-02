using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class FinishGame : MonoBehaviour
{
    [SerializeField]
    GameObject finishGamePanel;


    void Start()
    {

        finishGamePanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }



   public void Restrat()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;

    }

    public void LoadStartMenuScene()
    {
        SceneManager.LoadScene("StartMenu");
    }
}


