using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private Text CurrentScoreText;
    [SerializeField] private Text CurrentScoreText2;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject GamePausePanel;
    [SerializeField] private GameObject CurrentGamePanel;
    [SerializeField] private Text LastScoreText;
    [SerializeField] private Text HighScoreText;
    [SerializeField] private GameObject JoyStickCont;
    public void SetScoreText(int score)
    {
        if (CurrentScoreText)
        {
            CurrentScoreText.text = "Score: " + score;
            CurrentScoreText2.text = "Score: " + score;
        }
    }

    public void SetLastScoreText(int lastScore)
    {
        if (LastScoreText)
        {
            LastScoreText.text = "Score: " + lastScore;
        }
    }

    public void SetHighScoreText(int highScore)
    {
        if(HighScoreText)
        {
            HighScoreText.text = "High Score: " + highScore;
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

    public void showJoyStickCont(bool isShow)
    {
        if (JoyStickCont)
        {
            JoyStickCont.SetActive(isShow);
        }
    }
}
