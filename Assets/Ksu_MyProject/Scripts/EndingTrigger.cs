using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    public GameObject endingPanel; // 엔딩 패널 오브젝트 참조

    private void Start()
    {
        endingPanel.SetActive(false); // 시작할 때 엔딩 패널을 비활성화
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            endingPanel.SetActive(true); // 플레이어가 트리거에 진입하면 엔딩 패널을 활성화
        }
    }
}
