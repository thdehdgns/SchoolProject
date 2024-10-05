using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI Days;
    public TextMeshProUGUI Totime;
    private MainGamePlay Sedd;
    public GameObject night;
    public int ToDay = 1;
    private string AD = ""; 
    public int DayScore = 0;

    //�ణ ����ȭ�Ϸ��� updata�� ���� ���⿡ �Լ��ϳ� ���� �ٸ� �ڵ忡�� �� �Լ� ��� ȣ���ϸ�Ǵµ� �ǰ� ������

    private void Awake()
    {
        // instance�� �̹� �����ϴ� ���, ���� ������ ������Ʈ�� �ı�
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            // �� ������Ʈ�� �� ��ȯ���� �ı����� �ʵ��� ����
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void Update()
    {
        ScoreReset();
        Istime();
    }

    private void Istime()
    {
        switch (DayScore)
        {
            case 0:
                AD = "��ħ";
                night.SetActive(false);
                break;
            case 1:
                AD = "����";
                break;
            case 2:
                AD = "����";
                night.SetActive(true);
                break;
            default:
                Debug.LogWarning("�ð��� �̻��մϴ�.");
                break;
        }
        

    }

    public void Sun()//��ư���� ����
    {
        Sedd = GameObject.Find("Seed").GetComponent<MainGamePlay>();   //�ν����� â���� Seed�� ã�� ���۳�Ʈ ���� ����
        int random = Random.Range(10, 15);
        Sedd.SunnyP += random;
        if (random >= 15)
        {
            //�������� ȿ���� ���� ���� ����
        }
        Sedd.humidityP -= 10;
        random = Random.Range(10, 25);
        Sedd.freshP += random;
        DayScore += 1;
    }

    public void Water()//��ư���� ����
    {
        Sedd = GameObject.Find("Seed").GetComponent<MainGamePlay>();
        int random = Random.Range(5, 10);
        if(random >= 10)
        {
            //�������� �������ߴ� ����Ʈ ����
        }

        Sedd.humidityP += random;
        DayScore += 1;
        Sedd.SunnyP -= 5;

    }

    private void ScoreReset()
    {
        Days.text = $"{ToDay}  ����";
        Totime.text = $"{AD}";
        if (DayScore >= 3)
        {
            Sedd = GameObject.Find("Seed").GetComponent<MainGamePlay>();
            int random = Random.Range(5, 20);
            Sedd.freshP -= random;  //�Ϸ� ���������� �ż����� ����
            ToDay += 1;
            DayScore = 0;
        }


        if(ToDay >= 15)
        {
            Time.timeScale = 0f;
        }
    }
}
