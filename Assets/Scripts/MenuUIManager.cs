using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject SoundPanel;

    public void ShowSoundPanel(bool isShow)
    {
        if (isShow)
        {
            MenuPanel.SetActive(false);
            SoundPanel.SetActive(true);
        }
        else
        {
            MenuPanel.SetActive(true);
            SoundPanel.SetActive(false);
        }
    }
}
