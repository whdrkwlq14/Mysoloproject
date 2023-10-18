using UnityEngine;

public class ObjectMoveTrigger : MonoBehaviour
{
    public GameObject Statue;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;
    public float moveSpeed = 2.0f; // 움직임의 속도 조절

    void Start()
    {
        // 초기 위치 설정
        originalPosition = transform.position;
        // 목표 위치 설정 (x축으로 -5만큼 움직인 위치)
        targetPosition = originalPosition - new Vector3(5f, 0f, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 트리거에 플레이어가 진입하면 움직임 시작
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            // 천천히 오브젝트를 목표 위치로 이동 (Lerp 함수 사용)
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, step);

            // 목표 위치에 도달하면 움직임 중지
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }
}
