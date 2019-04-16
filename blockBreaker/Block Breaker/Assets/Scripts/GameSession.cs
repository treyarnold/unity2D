﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
  [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
  [SerializeField] int scorePerBlockDestroyed = 10;
  [SerializeField] TextMeshProUGUI scoreText;

  [SerializeField] int currentScore = 0;
  
  private void Awake()
  {
    int gameStatusCount = FindObjectsOfType<GameSession>().Length;
    if (gameStatusCount > 1)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
    else
    {
      DontDestroyOnLoad(gameObject);
    }
  }

  void Start()
  {
    scoreText.text = currentScore.ToString();
  }

  // Update is called once per frame
  void Update()
  {
    Time.timeScale = gameSpeed;
  }

  public void ResetGame()
  {
    Destroy(gameObject);
  }

  public void AddToScore()
  {
    currentScore += scorePerBlockDestroyed;
    scoreText.text = currentScore.ToString();
  }
}
