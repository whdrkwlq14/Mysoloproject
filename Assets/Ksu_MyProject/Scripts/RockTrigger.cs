using UnityEngine;

public class RockTrigger : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform spawnPoint;
    public float rollSpeed = 5f; // 바위의 굴러가는 속도
    public Transform player;     // 플레이어 캐릭터의 위치

    private bool isRolling = false;
    private GameObject currentRock;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isRolling)
        {
            isRolling = true;
            SpawnRock();
        }
    }

    void Update()
    {
        if (isRolling)
        {
            if (currentRock != null)
            {
                // 바위를 플레이어 방향으로 굴립니다.
                Vector2 direction = (player.position - currentRock.transform.position).normalized;
                currentRock.GetComponent<Rigidbody2D>().velocity = direction * rollSpeed;
            }
        }
    }

    void SpawnRock()
    {
        currentRock = Instantiate(rockPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D rockRigidbody = currentRock.GetComponent<Rigidbody2D>();
        rockRigidbody.gravityScale = 1111; // 중력을 0으로 설정하여 떨어지지 않도록 합니다.
    }
}
