using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("MainScenes");
    }
    public void GameExitBtn()
    {
        Application.Quit();
        Debug.Log("��������");
    }
}
