using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManger : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("MainScenes");
    }
}
