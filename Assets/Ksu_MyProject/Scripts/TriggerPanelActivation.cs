using UnityEngine;

public class TriggerPanelActivation : MonoBehaviour
{
    public GameObject E_Panel; //E_Panel 적용할 패널
    public GameObject TextPanel; // E키를 눌렀을때 불러올 textPanel 패널

    private bool canInterct = false; // 상호작용 초기화



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