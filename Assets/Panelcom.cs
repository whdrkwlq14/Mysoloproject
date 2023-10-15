using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panelcom : MonoBehaviour
{
    public GameObject uiPanel; // �ɼ� â UI �г�
    public GameObject ManualPanel; // ���۹� UI
    public Button CloseManualPanelButton; // �޴��� �ݱ��ư Ŭ�� ����
    public Button OpenUIPanelSettingButton;

    public bool OptionOpen = false;



    void Start()
    {
        ManualPanelOpen();
        CloseManualPanelButton.onClick.AddListener(CloseManualPanel); //��ư Ŭ�� �̺�Ʈ�� �޴��� �г� �ݱ� �Լ� ����
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC Key");
            if (OptionOpen)
            {
                CloseOption();
            }
            else
            {
                OpenOption();
            }
        }
    }


    void OpenOption()
    {
        uiPanel.SetActive(true);
        Time.timeScale = 0f; // ���� �Ͻ� ����
        OptionOpen = true;
    }

    void CloseOption()
    {
        uiPanel.SetActive(false);
        Time.timeScale = 1f; // ���� �簳
        OptionOpen = false;
    }
    void ManualPanelOpen()
    {
        ManualPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    void CloseManualPanel()
    {
        ManualPanel.SetActive(false);
        Time.timeScale = 1f; // �Ŵ��� �г��� �ݰ� ���� �簳
    }
}
