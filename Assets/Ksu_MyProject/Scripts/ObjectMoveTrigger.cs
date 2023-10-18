using UnityEngine;

public class ObjectMoveTrigger : MonoBehaviour
{
    public GameObject Statue;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    public float moveSpeed = 2.0f; // �������� �ӵ� ����

    void Start()
    {
        // �ʱ� ��ġ ����
        originalPosition = transform.position;
        // ��ǥ ��ġ ���� (x������ -5��ŭ ������ ��ġ)
        targetPosition = originalPosition - new Vector3(5f, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Ʈ���ſ� �÷��̾ �����ϸ� ������ ����
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            // õõ�� ������Ʈ�� ��ǥ ��ġ�� �̵� (Lerp �Լ� ���)
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, step);

            // ��ǥ ��ġ�� �����ϸ� ������ ����
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }
}
