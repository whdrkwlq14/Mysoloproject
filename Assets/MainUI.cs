using UnityEngine;

public class MainUI : MonoBehaviour
{

    public void OnButtonClickNewGame()
    {
        Debug.Log("새 게임");
    }
    public void OnButtonClickLoad()
    {
        Debug.Log("불러오기");
    }
    public void OnButtonClickOption()
    {
        Debug.Log("옵션");
    }
    public void OnClickQuit()
    {
#if UNITY_EDTTOR
        unityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}