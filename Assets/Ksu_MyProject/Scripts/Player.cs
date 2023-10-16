using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _light;
    public float MoveSpeed = 10f; //�̵��ӵ� ����
    public float MaxHealth = 100; //�ִ� ����� ����
    public float NowHealth; // ���� ����� ����

    public Rigidbody2D rigid; // ������ٵ� ������Ʈ 

    float horizontalMove = 0f;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * MoveSpeed;
    }
}
