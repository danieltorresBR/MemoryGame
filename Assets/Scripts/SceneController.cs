using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class SceneController : Singleton<SceneController>
{
    private bool isLoading;
    private bool startLoading;
    private string targetSceneName;
    private float minLoadingTime;
    void Start()
    {
        if (base.SingletonStart())
        {
            startLoading = false;
            isLoading = false;
            targetSceneName = "";
            minLoadingTime = 1;
        }
    }
    void Update()
    {
        if (startLoading && !isLoading)
            StartCoroutine(StartLoadScene());
    }
    public IEnumerator StartLoadScene()
    {
        isLoading = true;

        GameObject.Find("FadeImage").GetComponent<Animator>().SetTrigger("show");
        yield return new WaitForEndOfFrame();
        if (GameObject.Find("FadeImage").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("FadeIn"))
            yield return new WaitForSeconds(GameObject.Find("FadeImage").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        AsyncOperation op = SceneManager.LoadSceneAsync("LoadingScene");
        while (!op.isDone)
            yield return new WaitForEndOfFrame();

        float timeLoading = Time.time + minLoadingTime;
        op = SceneManager.LoadSceneAsync(targetSceneName);
        op.allowSceneActivation = false;
        while (!op.isDone)
        {
            float percent = (op.progress / 0.9f) * 100;
            GameObject.Find("ProgessBar").GetComponent<Slider>().value = percent;
            GameObject.Find("Percent").GetComponent<Text>().text = String.Format("{0:0}", percent) + "%";
            if (percent == 100)
                break;
            yield return new WaitForEndOfFrame();
        }
        while (Time.time < timeLoading)
            yield return new WaitForEndOfFrame();
        op.allowSceneActivation = true;
        startLoading = false;
        isLoading = false;
        targetSceneName = "";
    }
    public void LoadScene(string targetSceneName)
    {
        this.targetSceneName = targetSceneName;
        startLoading = true;
    }
}