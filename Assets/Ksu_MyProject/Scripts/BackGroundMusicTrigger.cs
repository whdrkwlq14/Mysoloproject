using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicTrigger : MonoBehaviour
{
    public AudioSource backgroundMusic; // ��������� ������ Audio Source

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �÷��̾ Ʈ���ſ� �����ϸ�
        {
            // ������� ���
            if (backgroundMusic != null)
            {
                backgroundMusic.Play();
            }
        }
    }
}
