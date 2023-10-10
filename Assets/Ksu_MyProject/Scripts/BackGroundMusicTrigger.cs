using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicTrigger : MonoBehaviour
{
    public AudioSource backgroundMusic; // 배경음악을 제어할 Audio Source

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 플레이어가 트리거에 진입하면
        {
            // 배경음악 재생
            if (backgroundMusic != null)
            {
                backgroundMusic.Play();
            }
        }
    }
}
