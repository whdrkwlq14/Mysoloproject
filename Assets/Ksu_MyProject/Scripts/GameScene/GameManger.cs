using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("GameScenes");
    }
    public void GameExitBtn()
    {
        Application.Quit();
        Debug.Log("게임종료");
    }
}
