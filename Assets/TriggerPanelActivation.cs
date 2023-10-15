using UnityEngine;

public class TriggerPanelActivation : MonoBehaviour
{

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 플레이어와 충돌했을 때 실행할 동작
            Debug.Log("플레이어와 충돌했습니다.");
        }
    }
}
