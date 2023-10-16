using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panelcom : MonoBehaviour
{
    public GameObject uiPanel; // 옵션 창 UI 패널

    public GameObject ManualPanel; // 조작법 UI
    public Button CloseManualPanelButton; // 조작법 닫기 버튼 클릭 변수

    public Button OpenUIPanelSettingButton; // 옵션에서 조작법버튼 열기 클릭버튼

    public GameObject TextPanel;

    public bool isTextPanelActive = false;

    public bool OptionOpen = false; // 옵션 창



    void Start()
    {
        ManualPanelOpen();
        CloseManualPanelButton.onClick.AddListener(CloseManualPanel); //버튼 클릭 이벤트에 메뉴얼 패널 닫기 함수 연결
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
        Time.timeScale = 0f; // 게임 일시 정지
        OptionOpen = true;
    }

    void CloseOption()
    {
        uiPanel.SetActive(false);
        Time.timeScale = 1f; // 게임 재개
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
        Time.timeScale = 1f; // 매뉴얼 패널을 닫고 게임 재개
    }
}
