using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundSource;

    private void Start()
    {
        soundSource = GetComponent<AudioSource>();
        soundSource.Stop(); // 게임 시작 시 사운드 정지
    }

    public void PlaySound()
    {
        soundSource.Play(); // 사운드 재생
    }
}
