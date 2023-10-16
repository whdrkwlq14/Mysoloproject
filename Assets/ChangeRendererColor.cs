using UnityEngine;

public class ChangeRendererColor : MonoBehaviour
{
    public Color blackColor = Color.black; // ���������� ������ ����
    private Color originalColor;           // ���� ����
    private SpriteRenderer renderer;  // ��������Ʈ ������ ������Ʈ

    private void Start()
    {
        // ��������Ʈ ������ ������Ʈ ��������
        renderer = GetComponent <SpriteRenderer>();
        if (renderer != null)
        {
            originalColor = renderer.color; // ���� ���� ����
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ʈ���ſ� �÷��̾ �����ϸ�
        {
            ChangeColor(blackColor); // ������ ���������� ����
        }
    }

    private void ChangeColor(Color newColor)
    {
        if (renderer != null)
        {
            renderer.color = newColor;
        }
    }
}