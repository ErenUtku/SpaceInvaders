using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayScore : MonoBehaviour
{
    Text ScoreText;
    GameSession gameSession;

    void Start()
    {
        ScoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        ScoreText.text = gameSession.GetScore().ToString();
    }

}
