using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum GameStates{InTheGame,Pause,GameOver,Victory}
public class GameManager : MonoBehaviour
{public GameStates state;
Canvas pauseCanvas,gameOverCanvas,victoryCanvas,inTheGameCanvas;
public int myScore;
public static GameManager sharedInstance;

    public void pauseBehaviour()
    {
        if (Input.GetKeyDown(KeyCode.P)&&state==GameStates.InTheGame&&state!=GameStates.GameOver&&state!=GameStates.Victory&&state!=GameStates.Pause)
        {
            state = GameStates.Pause;
            pauseCanvas.enabled = true;
            victoryCanvas.enabled = false;
            inTheGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            Time.timeScale = 0;
        }
    }
    public void GameOverBehaviour()
    {
        if (state == GameStates.InTheGame && state != GameStates.Pause && state != GameStates.Victory)
        {
            state = GameStates.GameOver;
            pauseCanvas.enabled = false;
            victoryCanvas.enabled = false;
            inTheGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
            Time.timeScale = 0.75f;
        }
    }

    public void VictoryBehaviour()
    {
        if (state == GameStates.InTheGame && state != GameStates.GameOver && state != GameStates.Victory)
        {
            state = GameStates.Victory;
            pauseCanvas.enabled = false;
            victoryCanvas.enabled = true;
            inTheGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            Time.timeScale = 0.75f;
        }
    }

    public void InTheGameBehaviour()
    {
        if (state == GameStates.Pause && state != GameStates.GameOver && state != GameStates.Victory)
        {
            state = GameStates.InTheGame;
            pauseCanvas.enabled = false;
            victoryCanvas.enabled = false;
            inTheGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
            Time.timeScale = 1;
        }
    }

    public void GoToLvl(string name){SceneManager.LoadScene(name);}

    private void Awake()
    {sharedInstance = this;
    inTheGameCanvas=GameObject.Find("inTheGameCanvas").GetComponent<Canvas>();
    gameOverCanvas = GameObject.Find("gameOverCanvas").GetComponent<Canvas>();
    pauseCanvas = GameObject.Find("pauseCanvas").GetComponent<Canvas>();
    victoryCanvas = GameObject.Find("victoryCanvas").GetComponent<Canvas>();
    state=GameStates.InTheGame;}
}
