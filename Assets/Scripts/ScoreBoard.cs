using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int score;
    [SerializeField] TMP_Text scoreText;

    private void Start()
    {
        scoreText.text = score.ToString();
    }
    public void IncreaseScore(int amountOfPoints)
    {
        score += amountOfPoints;
        scoreText.text = score.ToString();
    }
}
