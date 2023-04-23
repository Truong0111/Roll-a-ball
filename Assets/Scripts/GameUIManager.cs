using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text CurrentScoreText;
    public GameObject GameOverPanel;
    public Text LastScoreText;

    public void SetScoreText(string scoreText)
    {
        if (CurrentScoreText)
        {
            CurrentScoreText.text = scoreText;
        }
    }

    public void SetLastScoreText(string lastScoreText)
    {
        if (LastScoreText)
        {
            LastScoreText.text = lastScoreText;
        }
    }

    public void showGameOverPanel(bool isShow)
    {
        if (GameOverPanel)
        {
            GameOverPanel.SetActive(isShow);
        }
    }
}