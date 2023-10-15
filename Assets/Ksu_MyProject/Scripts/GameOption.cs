using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOption : MonoBehaviour
{
    public GameObject optionPanel; // 옵션 창 UI 패널

    private bool isOptionOpen = false;

        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOptionOpen)
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
        optionPanel.SetActive(true);
        Time.timeScale = 0f; // 게임 일시 정지
        isOptionOpen = true;
    }

    void CloseOption()
    {
        optionPanel.SetActive(false);
        Time.timeScale = 1f; // 게임 재개
        isOptionOpen = false;
    }

    public void ResumeGame()
    {
        CloseOption();
    }
    public void GameMeunScenesMove()
    {
        SceneManager.LoadScene("GameMenuScenes");
    }
}
