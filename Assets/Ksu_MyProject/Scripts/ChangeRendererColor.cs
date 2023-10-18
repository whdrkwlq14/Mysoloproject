using UnityEngine;

public class ChangeRendererColor : MonoBehaviour
{
    public Color blackColor = Color.black; // 검은색으로 변경할 색상
    private Color originalColor;           // 원래 색상
    private SpriteRenderer renderer;  // 스프라이트 렌더러 컴포넌트

    private void Start()
    {
        // 스프라이트 렌더러 컴포넌트 가져오기
        renderer = GetComponent <SpriteRenderer>();
        if (renderer != null)
        {
            originalColor = renderer.color; // 원래 색상 저장
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 트리거에 플레이어가 진입하면
        {
            ChangeColor(blackColor); // 색상을 검은색으로 변경
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