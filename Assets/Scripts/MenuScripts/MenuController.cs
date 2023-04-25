using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    public MenuUIManager UiManager;
    public VolumeController VolGc;
    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void Sound()
    {
        UiManager.ShowSoundPanel(true);
    }

    public void BackFromSound()
    {
        UiManager.ShowSoundPanel(false);
        VolGc.SaveVolume();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
