using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreData : MonoBehaviour
{

    //Staticly typed property setup for EnemySpawner.Instance
    private static HighScoreData _instance;
    public static HighScoreData Instance
    {
        get => _instance;
        private set
        {
            //check if instance of this class already exists and if so keep orignal existing instance
            if (_instance == null)
            {
                _instance = value;
            }
            else if (_instance != value)
            {
                Debug.Log($"{nameof(HighScoreData)} instance already exists, destroy the duplicate!");
                Destroy(value);
            }
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public int score;
    public Text scoreDisplay;
    public Text highScoreDisplay;

    private void Start()
    {
        UpdateHighScore();
    }

    private void Update()
    {
        ScoreUpdate();
    }

    void ScoreUpdate()
    {
        scoreDisplay.text = score.ToString();

        CheckHighScore();
    }

    void CheckHighScore()
    {
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            UpdateHighScore();
        }
    }

    void UpdateHighScore()
    {
        highScoreDisplay.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

}
