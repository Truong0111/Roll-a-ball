using UnityEngine;
using UnityEngine.UI;
public class MenuUIManager : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject SoundPanel;
    public GameObject HighScorePanel;
    public Text HighScoreText;
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
    public void SetHighScoreText(string highScoreText)
    {
        if (HighScoreText)
        {
            HighScoreText.text = highScoreText;
        }
    }
}
