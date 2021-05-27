using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // reference to self
    public static int score; // static to make it easy to access accross all scripts & scenes

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>(); // self reference
        score = 0; // reset score
    }

    void Update()
    {
        scoreText.text = "Score: " + score; // update score display every frame
    }
}
