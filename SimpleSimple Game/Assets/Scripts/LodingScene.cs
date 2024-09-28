using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LodingScene : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public string[] Tooltip;
    private void Start()
    {
        RandDomTooltop();
        LoadScene("Scnen 2");   //시작화면 넘어오면 로딩 시작
    }


    private void RandDomTooltop()
    {
        int Randomvalue = Random.Range(0, Tooltip.Length);
        Text.text = $"{Tooltip[Randomvalue]}";
    }
    public void LoadScene(string sceneName)
    {
        // 코루틴을 호출하여 비동기 로딩 시작
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // 비동기 씬 로드 코루틴
    IEnumerator LoadSceneAsync(string sceneName)
    {
        // 비동기 방식으로 씬 로딩 시작
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // 씬이 로딩 완료될 때까지 대기
        while (!operation.isDone)
        {
            // 로딩 중일 때, 필요한 경우 다른 작업을 처리할 수 있음 (옵션)
            yield return null;
        }

        // 씬 로딩이 완료되면 자동으로 새로운 씬으로 전환됨
    }
}
