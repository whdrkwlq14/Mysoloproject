using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] float spikeForce;  // ���� �������� �������� ��
    [SerializeField] float spikeDamage = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�����浹");
            // �÷��̾� ĳ���Ϳ��� �������� ���� ������ �����մϴ�.
            Vector2 spikeDirection = (other.transform.position - transform.position).normalized;

            // �÷��̾� ĳ���Ϳ��� ���� ���մϴ�.
            other.GetComponent<Rigidbody2D>().AddForce(spikeDirection * spikeForce, ForceMode2D.Impulse);
            CharacterController2D CharacterController2D = other.GetComponent<CharacterController2D>();
            if(CharacterController2D != null)
            {
                Debug.Log("ĳ���Ϳ��� �����浹 1 ����� ����");
                CharacterController2D.ApplyDamage(spikeDamage);
            }
        }
    }
}
