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
        LoadScene("Scnen 2");   //����ȭ�� �Ѿ���� �ε� ����
    }


    private void RandDomTooltop()
    {
        int Randomvalue = Random.Range(0, Tooltip.Length);
        Text.text = $"{Tooltip[Randomvalue]}";
    }
    public void LoadScene(string sceneName)
    {
        // �ڷ�ƾ�� ȣ���Ͽ� �񵿱� �ε� ����
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // �񵿱� �� �ε� �ڷ�ƾ
    IEnumerator LoadSceneAsync(string sceneName)
    {
        // �񵿱� ������� �� �ε� ����
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // ���� �ε� �Ϸ�� ������ ���
        while (!operation.isDone)
        {
            // �ε� ���� ��, �ʿ��� ��� �ٸ� �۾��� ó���� �� ���� (�ɼ�)
            yield return null;
        }

        // �� �ε��� �Ϸ�Ǹ� �ڵ����� ���ο� ������ ��ȯ��
    }
}
