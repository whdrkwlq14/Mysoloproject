using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSceneButton : MonoBehaviour
{
    public GameObject SettingPanel;

    public void StartNewGame()
    {
        SceneManager.LoadScene("GameScenes");
    }
    public void SettingMenuOpen()
    {
        SettingPanel.SetActive(true); // 패널 온 오프
    }
    public void SettingMenuExit()
    {
        SettingPanel.SetActive(false);
    }
    public void GameExit()
    {
        Application.Quit();
        Debug.Log("게임종료");
    }
}
