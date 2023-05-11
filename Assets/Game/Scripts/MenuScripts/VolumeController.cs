using UnityEngine;
using UnityEngine.UI;
public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider VolumeSlider;
    
    private void Start()
    {
        LoadVolume();
    }
    public void SaveVolume()
    {
        float volumeValue = VolumeSlider.value;
        PlayerPrefs.SetFloat("MasterVol", volumeValue);
        LoadVolume();
    }

    public void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("MasterVol");
        VolumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
