using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text CurrentScoreText;
    public Text CurrentScoreText2;
    public GameObject GameOverPanel;
    public GameObject GamePausePanel;
    public GameObject CurrentGamePanel;
    public Text LastScoreText;
    public Text HighScoreText;

    public void SetScoreText(string scoreText)
    {
        if (CurrentScoreText)
        {
            CurrentScoreText.text = scoreText;
            CurrentScoreText2.text = scoreText;
        }
    }

    public void SetLastScoreText(string lastScoreText)
    {
        if (LastScoreText)
        {
            LastScoreText.text = lastScoreText;
        }
    }

    public void SetHighScoreText(string highScoreText)
    {
        if(HighScoreText)
        {
            HighScoreText.text = highScoreText;
        }
    }
    public void ShowCurrentGamePanel(bool isShow)
    {
        if (CurrentGamePanel)
        {
            CurrentGamePanel.SetActive(isShow);
        }
    }
    public void showGameOverPanel(bool isShow)
    {
        if (GameOverPanel)
        {
            ShowCurrentGamePanel(!isShow);
            GameOverPanel.SetActive(isShow);
        }
    }

    public void showGamePausePanel(bool isShow)
    {
        if (GamePausePanel)
        {
            ShowCurrentGamePanel(!isShow);
            GamePausePanel.SetActive(isShow);
        }
    }
}
