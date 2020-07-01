using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum GameState
{ 
    menu,
    inGame,
    gameOver
}
public class GameBehavior : MonoBehaviour
{
    public static GameBehavior instance;
    private int _scoreGame = 0;
    private int _destroyBlock = 0;
    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOver;


    public GameState currentGameState = GameState.menu;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void FixedUpdate()
    {

        NullObject();
    }

        public void StartGame()
    {
        Bullet.instance.StartGame();
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    void SetGameState (GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOver.enabled = false;
        }
        else if (newGameState == GameState.inGame)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOver.enabled = false;

        }
        else if (newGameState == GameState.gameOver)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOver.enabled = true;

        }

        currentGameState = newGameState;
    }


    void Start()
    {
        currentGameState = GameState.menu;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
            NullObject();
        }
    }

    public int Score
    {
        get { return _scoreGame; }

        set { _scoreGame = value; }
    }

    public int CoundDestroyBlock
    {
        get { return _destroyBlock; }

        set { _destroyBlock = value; }
    }

    void NullObject()
    {
        GameObject go = GameObject.FindWithTag("box");

        if (go == null)
        {
            SceneManager.LoadSceneAsync("YouWin");

        }
    }
}
