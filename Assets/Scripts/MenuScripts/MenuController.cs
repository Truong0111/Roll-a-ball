using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public MenuUIManager UiManager;
    public VolumeController VolGc;
    public int m_highScore ;
    private void Start()
    {
        LoadHighScore();
    }
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Sound()
    {
        UiManager.ShowSoundPanel(true);
    }
    public void HighScore()
    {
        UiManager.ShowHighScorePanel(true);
        UiManager.SetHighScoreText("High Score: " + m_highScore);
    }
    public void Reset()
    {
        m_highScore = 0;
        SaveHighScore();
        UiManager.SetHighScoreText("High Score: " + m_highScore);
    }
    public void BackFromSound()
    {
        UiManager.ShowSoundPanel(false);
        VolGc.SaveVolume();
    }

    public void BackFromHighScore()
    {
        UiManager.ShowHighScorePanel(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void SaveHighScore()
    {
        SaveSystem.SaveScore(this);
    }
    public void LoadHighScore()
    {
        ScoreData data = SaveSystem.LoadScore();
        m_highScore = data.highScore;
    }
}
