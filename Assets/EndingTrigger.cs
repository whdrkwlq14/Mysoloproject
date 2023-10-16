using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    public GameObject endingPanel; // ���� �г� ������Ʈ ����

    private void Start()
    {
        endingPanel.SetActive(false); // ������ �� ���� �г��� ��Ȱ��ȭ
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            endingPanel.SetActive(true); // �÷��̾ Ʈ���ſ� �����ϸ� ���� �г��� Ȱ��ȭ
        }
    }
}
