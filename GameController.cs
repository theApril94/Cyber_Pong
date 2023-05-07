using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;

    public Starter starter;

    private int scoreLeft = 0;
    private int scoreRight = 0;

    private bool Started = false;

    public Text scoreTextLeft;
    public Text scoreTextRight;

    private BallControlller ballController;

    private Vector3 startingPosition;


    void Start()
    {
        this.ballController = this.ball.GetComponent<BallControlller>();
        this.startingPosition = this.ball.transform.position;
    }

    
    void Update()
    {
        if (this.Started)
        {
            return;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            this.Started = true;
            this.starter.StartCountdown();
        }
    }

    public void StartGame()
    {
        this.ballController.Go();
    }

    public void ScoreGoalLeft()
    {
        Debug.Log("Score goal left");
        this.scoreLeft = +1;
        UpdateUI();
        ResetBall();
    }
    public void ScoreGoalRight()
    {
        Debug.Log("Score goal left");
        this.scoreRight = +1;
        UpdateUI();
        ResetBall();
    }

    private void UpdateUI()
    {
        this.scoreTextLeft.text = scoreLeft.ToString();
        this.scoreTextRight.text = scoreRight.ToString();   
    }

    private void ResetBall()
    {
        this.ballController.Stop();
        this.ball.transform.position = this.startingPosition;
        this.starter.StartCountdown();
    }

}
