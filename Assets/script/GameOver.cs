using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    bool gameOver;

    void Start()
    {
        //wordt naar speler gezocht als het vernietigd wordt
        FindObjectOfType<PlayerController>().OnPlayerDeath += OnGameOver;
    }
   	
	// Update is called once per frame
	void Update () {
        //door op spatiebalk te drukken kan je het spel opnieuw spelen
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    //method voor het gameover scherm
    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        //laat zien hoeveel seconden je overleeft hebt
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
