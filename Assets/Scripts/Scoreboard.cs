using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 120f;
    public int score1 = 0;
    public int score2 = 0;

    [SerializeField] Text Timer;
    [SerializeField] Text ScorePlayer1;
    [SerializeField] Text ScorePlayer2;
     
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime < 0)
            currentTime = 0;

        Timer.text = (currentTime).ToString("0");
        ScorePlayer1.text = score1.ToString();
        ScorePlayer2.text = score2.ToString();

        ScorePlayer1.text = GameObject.Find("SoccerBall").GetComponent<Ball>().p1score.ToString();
        ScorePlayer2.text = GameObject.Find("SoccerBall").GetComponent<Ball>().p2score.ToString();

    }
}
