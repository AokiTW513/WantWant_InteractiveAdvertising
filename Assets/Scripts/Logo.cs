using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public float fadeDuration = 1.5f;  // �H�J / �H�X���ɶ�
    public float stayDuration = 2f;    // ���d�ɶ�
    public AudioSource logoAudio;  // ���֨ӷ�

    public Image transitionImage;

    private Image logoImage;
    private Vector3 originalScale;
    public Vector3 targetScale = new Vector3(1f, 1f, 1f); // �̲פj�p�]�i�վ�^
    void Start()
    {
        logoImage = GetComponent<Image>();
        originalScale = transform.localScale * 0.5f; // �_�l�Y�p�@�b�]�i�̻ݨD�վ�^
        transform.localScale = originalScale;

        if (transitionImage != null)
        {
            Color c = transitionImage.color;
            c.a = 0f;
            transitionImage.color = c;
        }

        StartCoroutine(FadeLogo());
    }

    IEnumerator FadeLogo()
    {
        if (logoAudio != null)
        {
            logoAudio.Play();
        }

        // �H�J
        yield return StartCoroutine(FadeAndScale(0f, 1f, originalScale, targetScale));
        // ���d
        yield return new WaitForSeconds(stayDuration);
        // �H�X
        yield return StartCoroutine(FadeOnly(1f, 0f));

        LoadNextSence();
    }

    IEnumerator FadeAndScale(float alphaFrom, float alphaTo, Vector3 scaleFrom, Vector3 scaleTo)
    {
        float time = 0f;
        Color color = logoImage.color;

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;

            // �H�J/�H�X
            color.a = Mathf.Lerp(alphaFrom, alphaTo, t);
            logoImage.color = color;

            // ��j/�Y�p
            transform.localScale = Vector3.Lerp(scaleFrom, scaleTo, t);

            time += Time.deltaTime;
            yield return null;
        }
        color.a = alphaTo;
        logoImage.color = color;
        transform.localScale = scaleTo;
    }
    IEnumerator FadeOnly(float alphaFrom, float alphaTo)
    {
        float time = 0f;
        Color logocolor = logoImage.color;
        Color transitionImagecolor = transitionImage.color;

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;
            logocolor.a = Mathf.Lerp(alphaFrom, alphaTo, t);
            logoImage.color = logocolor;
            transitionImagecolor.a = Mathf.Lerp(0f, 1f, t);
            transitionImage.color = transitionImagecolor;

            time += Time.deltaTime;
            yield return null;
        }
        logocolor.a = alphaTo;
        logoImage.color = logocolor;
        transitionImagecolor.a = 1f;
        transitionImage.color = transitionImagecolor;
    }

    void LoadNextSence()
    {
        SceneManager.LoadScene("L1");
    }
}