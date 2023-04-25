using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text CurrentScoreText;
    public Text CurrentScoreText2;
    public GameObject GameOverPanel;
    public GameObject GamePausePanel;
    public Text LastScoreText;

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

    public void showGameOverPanel(bool isShow)
    {
        if (GameOverPanel)
        {
            GameOverPanel.SetActive(isShow);
        }
    }

    public void showGamePausePanel(bool isShow)
    {
        if (GamePausePanel)
        {
            GamePausePanel.SetActive(isShow);
        }
    }
}
