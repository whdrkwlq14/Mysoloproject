using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOption : MonoBehaviour
{
    public GameObject uiPanel; // �ɼ� â UI �г�
    public GameObject ManualPanel;

    public bool OptionOpen = false;


    void CloseOption()
    {
        uiPanel.SetActive(false);
        Time.timeScale = 1f; // ���� �簳
        OptionOpen = false;
    }

    public void ResumeGame()
    {
        CloseOption();
    }

    public void ExitManualPanel()
    {

        ManualPanel.SetActive(false);
    }

    public void ExitScenesMove()
    {
        SceneManager.LoadScene("GameMenuScenes");
    }
}
