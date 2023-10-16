using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIFadeImage : MonoBehaviour
{
    [SerializeField] float fadeDuration = 5f;
    [SerializeField] float delay = 2.0f;

    private Image image;
    private Text text;

    private void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(imageFadeOut());
    }

    IEnumerator imageFadeOut()
    {
        image.CrossFadeAlpha(1.0f, fadeDuration, false);
        yield return new WaitForSeconds(delay);
        yield return new WaitForSeconds(fadeDuration);  // 페이드인이 끝날때까지 대기상태로 만들어주고 끝난후에 다음 실행 
    }
}
