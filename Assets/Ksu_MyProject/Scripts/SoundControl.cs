using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    private float defaultVolume = 0.5f; // �⺻ ���� �� (�������� �ʾ��� ���� ��)

    void Start()
    {
        // ����� ���� ���� �ҷ���
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume");
            volumeSlider.value = savedVolume;
            audioSource.volume = savedVolume;
        }
        else
        {
            // ����� ���� ���� ��, �⺻ ���� ���� ����
            volumeSlider.value = defaultVolume;
            audioSource.volume = defaultVolume;
        }
    }

    public void OnVolumeSliderChange()
    {
        float newVolume = volumeSlider.value;
        audioSource.volume = newVolume;

        // ���ο� ���� ���� ����
        PlayerPrefs.SetFloat("MusicVolume", newVolume);
        PlayerPrefs.Save();
    }
}