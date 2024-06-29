using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Action onGameStarted;
    public BallSpawner spawner;
    public Player player;
    private bool isGameStarted;
    private float currentTimeScale;
    private int score;
    private int money;
    private float time;
    private float wastedTime;
    public float gameplayTimer = 60;
    public ParticleSystem effect;
    private void Awake()
    {
        instance = this;
        currentTimeScale = Time.timeScale;
        if (PlayerPrefs.HasKey("Money"))
        {
            money = PlayerPrefs.GetInt("Money");
        }
        else
        {
            PlayerPrefs.SetInt("Money", 0);
            PlayerPrefs.Save();
        }
        spawner.enabled = false;
    }
    private void Start()
    {
        UIManager.instance.ShowMoney(money.ToString());
    }
    private void Update()
    {
        if (isGameStarted)
        {
            
            time += Time.deltaTime;
            if (time>=1)
            {
                --gameplayTimer;
                time = 0;
                UIManager.instance.ShowTime(gameplayTimer.ToString());
            }
            if (gameplayTimer<=0)
            {
                EndGame();
            }
            
        }
    }
    public void AddScore()
    {
        score += 1;
        UIManager.instance.ShowScore(score.ToString());
        effect.Play();
    }
    public void StartGame()
    {
        isGameStarted = true;
        onGameStarted?.Invoke();
        Time.timeScale = 1f;
        UIManager.instance.ShowTime(gameplayTimer.ToString());
        spawner.enabled = true;
        //player.isCanAttack = true;
    }
    public void PauseGame()
    {
        isGameStarted = false;
        Time.timeScale = 0f;
        spawner.enabled = false;
    }
    public void UnPauseGame()
    {
        isGameStarted = true;
        Time.timeScale = currentTimeScale;
        spawner.enabled = true;
    }
    public void EndGame()
    {
        isGameStarted = false;
        CheckBestScore();
        UIManager.instance.EndGame();
        spawner.enabled = false;
    }
    private void CheckBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            int tempBestScore = PlayerPrefs.GetInt("BestScore");
            if (tempBestScore > score)
            {
                UIManager.instance.ShowBestScore(tempBestScore.ToString());
            }
            else
            {
                UIManager.instance.ShowBestScore(score.ToString());
                PlayerPrefs.SetInt("BestScore", score);
                PlayerPrefs.Save();
            }
        }
        else
        {
            UIManager.instance.ShowBestScore(score.ToString());
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.Save();
        }
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + score);
    }
    public bool IsGameStarted()
    {
        return isGameStarted;
    }
}
