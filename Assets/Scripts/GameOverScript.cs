using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text winner;
    public Text player1;
    public Text player2;
    public Text allShots;
    void Start()
    {
        GameObject go = GameObject.Find("Winner");
        winner = go.GetComponent<Text>();
        if (GameStatistick.ScorePlayer1 > GameStatistick.ScorePlayer2) winner.text += "Player 1";
        else winner.text = $"Winner : Player 2";

        go = GameObject.Find("Player1Score");
        player1 = go.GetComponent<Text>();
        player1.text += GameStatistick.ScorePlayer1.ToString();

        go = GameObject.Find("Player2Score");
        player2 = go.GetComponent<Text>();
        player2.text += GameStatistick.ScorePlayer2.ToString();

        go = GameObject.Find("AllShots");
        allShots = go.GetComponent<Text>();
        allShots.text += GameStatistick.Shots.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        GameStatistick.ScorePlayer1 = 0;
        GameStatistick.ScorePlayer2 = 0;
        GameStatistick.Shots = 0;
        SceneManager.LoadScene("StartMenu");
    }
}
