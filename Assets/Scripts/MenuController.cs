using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    public MenuUIManager UiManager;

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
    }
    public void Exit()
    {
        Application.Quit();
    }
}
