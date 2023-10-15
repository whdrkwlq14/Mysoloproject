using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panelcom : MonoBehaviour
{
    public GameObject uiPanel; // �ɼ� â UI �г�

    public GameObject ManualPanel; // ���۹� UI
    public Button CloseManualPanelButton; // ���۹� �ݱ� ��ư Ŭ�� ����

    public Button OpenUIPanelSettingButton; // �ɼǿ��� ���۹���ư ���� Ŭ����ư

    public GameObject TextPanel;

    public bool isTextPanelActive = false;

    public bool OptionOpen = false; // �ɼ� â



    void Start()
    {
        ManualPanelOpen();
        CloseManualPanelButton.onClick.AddListener(CloseManualPanel); //��ư Ŭ�� �̺�Ʈ�� �޴��� �г� �ݱ� �Լ� ����
        TextPanel.SetActive(false);
    }

    void Update()
    {
        OpenUIPanelSettingButton.onClick.AddListener(ManualPanelOpen);

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    if (isTextPanelActive)
        //    {
        //        isTextPanelActive = false;
        //    }
        //    else
        //    {
        //        isTextPanelActive = true;
        //    }
        //    TextPanel.SetActive(isTextPanelActive);

        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC Key");
            if (OptionOpen)
            {
                CloseOption();
                CloseManualPanel();
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
