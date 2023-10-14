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
        if (NextScene && Input.anyKeyDown) //입력이 들어오고, 아무 키를 눌렀을때)
        {       
            SceneManager.LoadScene("GameStartScenes"); // 다음 씬을 실행
        }
    }

    IEnumerator textFadein()
    {
        titletext.CrossFadeAlpha(1.0f, fadeDuration, false);
        yield return new WaitForSeconds(fadeDuration);  // 페이드인이 끝날때까지 대기상태로 만들어주고 끝난후에 다음 실행
        active.SetActive(true);

        NextScene = true; // 페이드인이 끝나고 입력이 들어왔을때 


    }

}
