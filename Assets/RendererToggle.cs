using UnityEngine;

public class RendererToggle : MonoBehaviour
{
    private Renderer playerRenderer;
    public SoundManager soundManager;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    // 플레이어가 특정 영역에 진입할 때 호출
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleRenderer(true); // 렌더러 활성화
            soundManager.PlaySound();
        }
    }

    // 플레이어가 특정 영역을 빠져나올 때 호출
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleRenderer(false); // 렌더러 비활성화
        }
    }

    private void ToggleRenderer(bool enable)
    {
        if (playerRenderer != null)
        {
            playerRenderer.enabled = enable;
        }
    }
}