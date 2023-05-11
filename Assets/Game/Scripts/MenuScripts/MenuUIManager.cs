using UnityEngine;
using UnityEngine.UI;
public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject SoundPanel;
    [SerializeField] private GameObject HighScorePanel;
    [SerializeField] private Text HighScoreText;
    public void ShowSoundPanel(bool isShow)
    {
        MenuPanel.SetActive(!isShow);
        SoundPanel.SetActive(isShow);
    }

    public void ShowHighScorePanel(bool isShow)
    {
        MenuPanel.SetActive(!isShow);
        HighScorePanel.SetActive(isShow);
    }
    public void SetHighScoreText(int highScore)
    {
        if (HighScoreText)
        {
            HighScoreText.text = "High Score: " + highScore;
        }
    }
}
