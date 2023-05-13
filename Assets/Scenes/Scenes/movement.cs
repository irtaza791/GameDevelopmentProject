using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // This is needed to use TextMeshPro

public class movement : MonoBehaviour
{
    public float speed = 0.1f;
    public GameObject cube; // Assign your cube here in inspector
    public TMP_Text scoreText; // Assign your TextMeshPro text here in inspector

    private int score = 0; // Initialize score

    void Start()
    {
        // Ensure score is set to 0 at the start
        UpdateScore();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with is the cube
        if (collision.gameObject == cube)
        {
            // Increase score and update the score text
            score++;
            UpdateScore();
        }
    }

    // Updates the score text to reflect current score
    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
