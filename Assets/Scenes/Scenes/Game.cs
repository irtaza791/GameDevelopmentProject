using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasedPerSecond;
    public float baseScoreIncreasePerSecond;
    public float milkIncreaseCost;
    public float flourIncreaseCost;

    void Start()
    {
        currentScore = 0;
        hitPower = 1;
        baseScoreIncreasePerSecond = 1;
        scoreIncreasedPerSecond = baseScoreIncreasePerSecond;
        milkIncreaseCost = 10;
        flourIncreaseCost = 20;
    }

    public void MilkIncrease()
    {
        if (currentScore >= milkIncreaseCost)
        {
            scoreIncreasedPerSecond += 1;
            currentScore -= milkIncreaseCost;
            milkIncreaseCost += 10;
        }
    }

    public void FlourIncrease()
    {
        if (currentScore >= flourIncreaseCost)
        {
            scoreIncreasedPerSecond *= 4;
            currentScore -= flourIncreaseCost;
            flourIncreaseCost += 20;
        }
    }

    void Update()
    {
        currentScore += scoreIncreasedPerSecond * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(currentScore).ToString() + " $";
    }

    public void Hit()
    {
        currentScore += hitPower;
    }
}
