using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform _light;
    public float MoveSpeed = 10f; //이동속도 설정
    public float MaxHealth = 100; //최대 생명력 설정
    public float NowHealth; // 현재 생명력 설정

    public Rigidbody2D rigid; // 리지드바디 컴포넌트 

    float horizontalMove = 0f;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * MoveSpeed;
    }
}
