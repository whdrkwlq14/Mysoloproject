using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundSource;

    private void Start()
    {
        soundSource = GetComponent<AudioSource>();
        soundSource.Stop(); // ���� ���� �� ���� ����
    }

    public void PlaySound()
    {
        soundSource.Play(); // ���� ���
    }
}
