using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private float defaultVolume = 0.5f; // 기본 볼륨 값 (설정되지 않았을 때의 값)

    void Start()
    {
        // 저장된 볼륨 값을 불러옴
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            volumeSlider.value = savedVolume;
            audioSource.volume = savedVolume;
        }
        else
        {
            // 저장된 값이 없을 때, 기본 볼륨 값을 설정
            volumeSlider.value = defaultVolume;
            audioSource.volume = defaultVolume;
        }
    }

    public void OnVolumeSliderChange()
    {
        float newVolume = volumeSlider.value;
        audioSource.volume = newVolume;

        // 새로운 볼륨 값을 저장
        PlayerPrefs.SetFloat("MusicVolume", newVolume);
        PlayerPrefs.Save();
    }
}