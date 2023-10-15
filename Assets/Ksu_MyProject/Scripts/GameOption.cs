using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOption : MonoBehaviour
{
    public GameObject optionPanel; // �ɼ� â UI �г�

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
        Time.timeScale = 0f; // ���� �Ͻ� ����
        isOptionOpen = true;
    }

    void CloseOption()
    {
        optionPanel.SetActive(false);
        Time.timeScale = 1f; // ���� �簳
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
