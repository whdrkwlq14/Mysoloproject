using UnityEngine;

public class TriggerPanelActivation : MonoBehaviour
{

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �÷��̾�� �浹���� �� ������ ����
            Debug.Log("�÷��̾�� �浹�߽��ϴ�.");
        }
    }
}
