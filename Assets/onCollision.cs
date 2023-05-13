using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour
{
    public int score = 0;
    public UnityEngine.UI.Text scoreText; // Fully qualified Text type

    private void Start()
    {
        // Initialize the score text
        UpdateScoreText();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "chest")
        {
            Destroy(col.gameObject);
            score++;
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
