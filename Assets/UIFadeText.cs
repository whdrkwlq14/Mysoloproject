using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIFadeText : MonoBehaviour
{
    [SerializeField] float fadeDuration = 0f;
    private Text titletext;

    private bool NextScene = false;

    public GameObject active;

    private void Start()
    {

        titletext = GetComponent<Text>();
        titletext.canvasRenderer.SetAlpha(0.0f);

        active.SetActive(false);

        StartCoroutine(textFadein());


    }

    void Update()
    {
        if (NextScene && Input.anyKeyDown) //�Է��� ������, �ƹ� Ű�� ��������)
        {       
            SceneManager.LoadScene("GameStartScenes"); // ���� ���� ����
        }
    }

    IEnumerator textFadein()
    {
        titletext.CrossFadeAlpha(1.0f, fadeDuration, false);
        yield return new WaitForSeconds(fadeDuration);  // ���̵����� ���������� �����·� ������ְ� �����Ŀ� ���� ����
        active.SetActive(true);

        NextScene = true; // ���̵����� ������ �Է��� �������� 


    }

}
