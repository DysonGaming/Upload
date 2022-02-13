using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random=UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public PlayerSetup Music;
    public AudioManager StartMusic;
    public PlayerStats PointStats;

    public GameObject GameOverPanel;
    public GameObject GamePlay;

    public int countdownTime;
    public bool gamePlaying = false;

    public Text TimeCounter;
    public Text countdownDisplay;

    private float startTime, elapsedTime;
    TimeSpan timePlaying;

    public int pointStack;
    public Text pointDisplay;
    public Text Endpoints;

    private void Start() 
    {
        gamePlaying = false;
        StartCoroutine(CountdownToStart());
        pointDisplay.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void BeginGame() 
    {
        gamePlaying = true;
        startTime = Time.time;
       
        pointDisplay.gameObject.SetActive(true);       
        StartCoroutine(PointSystem());

        StartMusic.StartSongs();
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0) 
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        countdownDisplay.text = "GO!";

        BeginGame();

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
    }

    IEnumerator PointSystem()
    {
        while(gamePlaying) 
        {
            pointDisplay.text = pointStack.ToString();

            yield return new WaitForSeconds(5f);

            pointStack++;
        }
        pointDisplay.gameObject.SetActive(false);
    }

    private void Update() 
    {
        if (gamePlaying) 
        {
            elapsedTime = Time.time - startTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);

            string timePlayingStr = "Time " + timePlaying.ToString("mm':'ss'.'ff");
            TimeCounter.text = timePlayingStr;
        }
    }

    public void GameOver() 
    {
        gamePlaying = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameOverPanel.SetActive(true);
        GamePlay.SetActive(false);

        string timePlayingStr = "Time " + timePlaying.ToString("mm':'ss'.'ff");
        GameOverPanel.transform.Find("EndTime").GetComponent<Text>().text = timePlayingStr;

        Endpoints.text = pointStack.ToString();

        PointStats.handleScore(pointStack);

        Debug.Log("Game Over");
    }
}
