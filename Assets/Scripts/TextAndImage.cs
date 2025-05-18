using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class SceneData
{
    public string text;
    public Sprite[] images;
}

public class TextAndImage : MonoBehaviour
{
    [Header("UI")]
    public Text Storytext;
    public Button nextButton;
    public Button KnowMuchButton;
    public Image[] displayImages;

    [Header("Scene")]
    public SceneData[] scenes;
    public float startWait = 1f;
    public float typeSpeed = 0.05f;
    public float fadeDuration = 1.5f;

    private bool isNextPressed = false;

    public GameObject playGameUI;
    public GameObject storyUI;
    public int gameTriggerIndex = 5;

    void Start()
    {
        foreach (var img in displayImages)
            img.enabled = false;

        nextButton.onClick.AddListener(() => isNextPressed = true);
        nextButton.gameObject.SetActive(false);
        KnowMuchButton.onClick.AddListener(() => SceneManager.LoadScene("Introduce"));
        KnowMuchButton.gameObject.SetActive(false);
        playGameUI.SetActive(false);
        StartCoroutine(PlayScenes());
    }

    IEnumerator PlayScenes()
    {
        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < scenes.Length; i++)
        {
            yield return StartCoroutine(FadeOutAllImages());

            if (i == gameTriggerIndex)
            {
                storyUI.SetActive(false);
                playGameUI.SetActive(true);

                var chooseScript = playGameUI.GetComponent<Choose>();
                chooseScript._isPlaying = true;

                yield return new WaitUntil(() => chooseScript._isWin || chooseScript._isLose);

                playGameUI.SetActive(false);
                storyUI.SetActive(true);
                continue;
            }

            var scene = scenes[i];
            Storytext.text = "";

            for (int j = 0; j < displayImages.Length; j++)
            {
                if (j < scene.images.Length && scene.images[j] != null)
                {
                    displayImages[j].sprite = scene.images[j];
                    displayImages[j].enabled = true;
                    yield return StartCoroutine(FadeInImage(displayImages[j]));
                }
                else
                {
                    displayImages[j].enabled = false;
                }
            }

            yield return StartCoroutine(TypeText(scene.text));

            if(i < scenes.Length - 1)
            {
                isNextPressed = false;
                nextButton.gameObject.SetActive(true);
                yield return new WaitUntil(() => isNextPressed);
                nextButton.gameObject.SetActive(false);
            } 
            if(i == scenes.Length - 1)
            {
                KnowMuchButton.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator TypeText(string content)
    {
        Storytext.text = "";
        foreach (char c in content)
        {
            Storytext.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    IEnumerator FadeInImage(Image img)
    {
        Color color = img.color;
        color.a = 0;
        img.color = color;

        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(0, 1, time / fadeDuration);
            img.color = color;
            yield return null;
        }

        color.a = 1;
        img.color = color;
    }

    IEnumerator FadeOutImage(Image img)
    {
        if (img.sprite == null) yield break;

        Color color = img.color;
        color.a = 1;
        img.color = color;

        float time = 0f;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Lerp(1, 0, time / fadeDuration);
            img.color = color;
            yield return null;
        }

        color.a = 0;
        img.color = color;
        img.enabled = false;
    }

    IEnumerator FadeOutAllImages()
    {
        List<Coroutine> fadeOuts = new List<Coroutine>();
        foreach (var img in displayImages)
        {
            if (img.enabled && img.sprite != null)
                fadeOuts.Add(StartCoroutine(FadeOutImage(img)));
        }
        foreach (var co in fadeOuts)
        {
            yield return co;
        }

        Storytext.text = "";
    }


}
