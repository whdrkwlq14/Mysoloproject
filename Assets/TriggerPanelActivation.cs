using UnityEngine;

public class TriggerPanelActivation : MonoBehaviour
{
    public GameObject E_Panel; //E_Panel ������ �г�
    public GameObject TextPanel; // EŰ�� �������� �ҷ��� textPanel �г�

    private bool canInterct = false; // ��ȣ�ۿ� �ʱ�ȭ



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInterct = true;
            E_Panel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInterct=false;
            TextPanel.SetActive(false);
            E_Panel.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (canInterct && Input.GetKeyDown(KeyCode.E))
        {
            TextPanel.SetActive(!TextPanel.activeSelf);
            E_Panel.SetActive(!E_Panel.activeSelf);
        }
    }
}