using UnityEngine;

public class MainUI : MonoBehaviour
{

    public void OnButtonClickNewGame()
    {
        Debug.Log("�� ����");
    }
    public void OnButtonClickLoad()
    {
        Debug.Log("�ҷ�����");
    }
    public void OnButtonClickOption()
    {
        Debug.Log("�ɼ�");
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