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

    // �÷��̾ Ư�� ������ ������ �� ȣ��
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleRenderer(true); // ������ Ȱ��ȭ
            soundManager.PlaySound();
        }
    }

    // �÷��̾ Ư�� ������ �������� �� ȣ��
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleRenderer(false); // ������ ��Ȱ��ȭ
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