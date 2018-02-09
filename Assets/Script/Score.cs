using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private float lastTime = 0;
    private float interval = 0.3f;

    private string full_score_text;
    public int score = 0;
    public Text scoreText;
    public PlayerHP playerHp;

    public Text bestScoreText;

    // Use this for initialization
    private void Start () {
        //playerhp = GetComponent<PlayerHP>();
        var bestScore = PlayerPrefs.GetInt("BEST_SCORE", 0);
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time - lastTime > interval && !playerHp.over)
        {
            setScore();
            lastTime = Time.time;
        }

     }

    private void setScore()
    {
        score += 1;
        full_score_text = "Score: " + score;
        scoreText.text = full_score_text;
    }

    public void BestScore()
    {
        var bestScore = PlayerPrefs.GetInt("BEST_SCORE", 0);
        bestScoreText.text = "Best Score: " + bestScore.ToString();

        if (bestScore < score)
        {
            PlayerPrefs.SetInt("BEST_SCORE", score);
            PlayerPrefs.Save();
        }      
    }
}
