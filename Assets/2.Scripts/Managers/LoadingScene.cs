using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    public Slider progressBar;
    public TMP_Text progressText;

    void Start()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        string sceneToLoad =
            PlayerPrefs.GetString("SceneToLoad");

        AsyncOperation operation =
            SceneManager.LoadSceneAsync(sceneToLoad);

        operation.allowSceneActivation = false;

        float timer = 0f;

        while (operation.progress < 0.9f)
        {
            float progress =
                Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.value = progress;

            progressText.text =
                (progress * 100f).ToString("F0") + "%";

            yield return null;
        }

        progressBar.value = 1f;
        progressText.text = "100%";

        while (timer < 1f)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }
}