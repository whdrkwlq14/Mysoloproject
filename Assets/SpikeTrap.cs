using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] float spikeForce;  // 가시 함정에서 가해지는 힘
    [SerializeField] float spikeDamage = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("가시충돌");
            // 플레이어 캐릭터에게 가해지는 힘의 방향을 설정합니다.
            Vector2 spikeDirection = (other.transform.position - transform.position).normalized;

            // 플레이어 캐릭터에게 힘을 가합니다.
            other.GetComponent<Rigidbody2D>().AddForce(spikeDirection * spikeForce, ForceMode2D.Impulse);
            CharacterController2D CharacterController2D = other.GetComponent<CharacterController2D>();
            if(CharacterController2D != null)
            {
                Debug.Log("캐릭터에게 가시충돌 1 대미지 받음");
                CharacterController2D.ApplyDamage(spikeDamage);
            }
        }
    }
}
