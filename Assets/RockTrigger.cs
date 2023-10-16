using UnityEngine;

public class RockTrigger : MonoBehaviour
{
    public GameObject rockPrefab;
    public Transform spawnPoint;
    public float rollSpeed = 5f; // ������ �������� �ӵ�
    public Transform player;     // �÷��̾� ĳ������ ��ġ

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
                // ������ �÷��̾� �������� �����ϴ�.
                Vector2 direction = (player.position - currentRock.transform.position).normalized;
                currentRock.GetComponent<Rigidbody2D>().velocity = direction * rollSpeed;
            }
        }
    }

    void SpawnRock()
    {
        currentRock = Instantiate(rockPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D rockRigidbody = currentRock.GetComponent<Rigidbody2D>();
        rockRigidbody.gravityScale = 1111; // �߷��� 0���� �����Ͽ� �������� �ʵ��� �մϴ�.
    }
}
